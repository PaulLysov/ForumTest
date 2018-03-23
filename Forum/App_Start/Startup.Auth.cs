using System;
using Forum.Providers;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;

namespace Forum
{
	public partial class Startup
	{
		public static OAuthAuthorizationServerOptions OAuthOptions { get; private set; }

		// For more information on configuring authentication, please visit http://go.microsoft.com/fwlink/?LinkId=301864
		public void ConfigureAuth(IAppBuilder app)
		{
			OAuthOptions = new OAuthAuthorizationServerOptions
			{
				AccessTokenExpireTimeSpan = new TimeSpan(24, 0, 0),
				TokenEndpointPath = new PathString("/Token"),
				Provider = new ApplicationOAuthProvider(),
				AllowInsecureHttp = true
			};

			// Enable the application to use bearer tokens to authenticate users
			app.UseOAuthBearerTokens(OAuthOptions);

			// Uncomment the following lines to enable logging in with third party login providers
			//app.UseMicrosoftAccountAuthentication(
			//    clientId: "",
			//    clientSecret: "");

			//app.UseTwitterAuthentication(
			//    consumerKey: "",
			//    consumerSecret: "");

			//app.UseFacebookAuthentication(
			//    appId: "",
			//    appSecret: "");

			//app.UseGoogleAuthentication(new GoogleOAuth2AuthenticationOptions()
			//{
			//    ClientId = "",
			//    ClientSecret = ""
			//});

		}
	}
}
