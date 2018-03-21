using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using System.Web;
using System.Web.Security;
using Forum.Core.Services;
using Forum.Domain.User;
using Forum.Domain.User.Roles;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OAuth;
using WebMatrix.WebData;

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

			var userService = new UserService();
			var user = userService.GetUserByEmail(context.UserName);
			if (user == null)
			{
				throw new Exception($"User not found at current login = [{context.UserName}]");
			}

			try
			{
				if (user.LockoutEnabled)
					throw new Exception("Account is lockout");
			}
			catch (Exception ex)
			{
				context.SetError("invalid_grant", ex.Message);
				return Task.FromResult<object>(null);
			}

			var roleName = Enum.GetName(typeof(RoleType), user.RoleId);
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

		public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
		{
			// Resource owner password credentials does not provide a client ID.
			if (context.ClientId == null)
			{
				context.Validated();
			}

			return Task.FromResult<object>(null);
		}

		public static AuthenticationProperties CreateProperties(string userName)
		{
			IDictionary<string, string> data = new Dictionary<string, string>
			{
				{ "userName", userName }
			};
			return new AuthenticationProperties(data);
		}
	}
}