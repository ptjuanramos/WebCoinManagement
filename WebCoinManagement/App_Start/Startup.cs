using System;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OAuth;
using Owin;
using WebCoinManagement.Areas.Api;

[assembly: OwinStartup(typeof(WebCoinManagement.App_Start.Startup))]
namespace WebCoinManagement.App_Start
{
    public class Startup
    {
        
        public void Configuration(IAppBuilder baseAppBuilder)
        {
            ConfigureAuth(baseAppBuilder);
        }

        private void ConfigureWebAuth(IAppBuilder appBuilder)
        {
            appBuilder.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"),
                AuthenticationMode = Microsoft.Owin.Security.AuthenticationMode.Active,

            });
        }

        private void ConfigureApiAuth(IAppBuilder appBuilder)
        {
            var OAuthOptions = new OAuthAuthorizationServerOptions
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/Api/Account/Login"),
                AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(20),
                Provider = new CoinManagAPIAuthorizationServerProvider()
            };

            appBuilder.UseOAuthAuthorizationServer(OAuthOptions);
            appBuilder.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
        }

        private void ConfigureAuth(IAppBuilder appBuilder)
        {
            appBuilder.MapWhen(context => !context.Request.Path.StartsWithSegments(new PathString("/Api")), ConfigureWebAuth);
            appBuilder.MapWhen(context => context.Request.Path.StartsWithSegments(new PathString("/Api")), ConfigureApiAuth);

            HttpConfiguration config = new HttpConfiguration();
            WebApiConfig.Register(config);
        }
    }
}
