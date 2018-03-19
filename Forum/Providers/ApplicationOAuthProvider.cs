using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using System.Web;
using System.Web.Security;
using Microsoft.Owin.Security.OAuth;

namespace Forum.Providers
{
    public class ApplicationOAuthProvider : OAuthAuthorizationServerProvider
    {
        public const string AllScope = "all";

        public override Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            // HACK: the login method here is used to validate user credentials
            // In fact it does much more than validation, 
            // in particular it sets .ASPXAUTH cookie which is not needed.
            // Is there any other method that performs only validation?
            if (!WebSecurity.Login(context.UserName, context.Password))
            {
                context.SetError("invalid_grant", "Неправильный логин или пароль");
                return Task.FromResult<object>(null);
            }
            // cancel .ASPXAUTH cookie
            HttpContext.Current.Response.Cookies.Remove(FormsAuthentication.FormsCookieName);

            string roleName;
            using (var unitOfWork = new UnitOfWork())
            {
                var userRepository = new UserRepository(unitOfWork);
                var user = userRepository.GetByEmail(context.UserName);
				if (user == null)
                {
                    throw new Exception("Пользователя с email " + context.UserName + " нет в базе");
                }
                
                try
                {
                    LoginHelper.LoginChecks(user);
                }
                catch (LoginException ex)
                {
                    context.SetError("invalid_grant", ex.Message);
                    return Task.FromResult<object>(null);
                }
                LoginHelper.LogUserLogin(unitOfWork, user, context.Request.RemoteIpAddress,  context.Request.Headers.Get("User-Agent"));

                roleName = Enum.GetName(typeof(RoleType), user.RoleId);
            }

            var identity = new ClaimsIdentity(
                new GenericIdentity(context.UserName, OAuthDefaults.AuthenticationType),
                new Claim[] {
                    new Claim("urn:oauth:scope", AllScope),
                    new Claim(ClaimTypes.Role, roleName)
                }
            );

            context.Validated(identity);
            return Task.FromResult<object>(null);
        }

        public override Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
            foreach (KeyValuePair<string, string> property in context.Properties.Dictionary)
            {
                context.AdditionalResponseParameters.Add(property.Key, property.Value);
            }

            return Task.FromResult<object>(null);
        }

        /// <summary>
        /// Validate client authentication.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        /// <remarks>We must overwrite this method while the default implementation does not validate the context
        /// and the request will be rejected.</remarks>
        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            // Our client does not require authentication, hence mark the context as validated unconditionally.
            context.Validated();
            return Task.FromResult<object>(null);
        }
    }
}