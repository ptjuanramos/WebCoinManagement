using System;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;

[assembly: OwinStartup(typeof(WebCoinManagement.App_Start.Startup))]

namespace WebCoinManagement.App_Start
{
    public class Startup
    {
        
        public void Configuration(IAppBuilder baseAppBuilder)
        {
            ConfigureAuth(baseAppBuilder);
        }

        private void ConfigureAuth(IAppBuilder appBuilder)
        {
            appBuilder.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"),
                AuthenticationMode = Microsoft.Owin.Security.AuthenticationMode.Active
            });
        }
    }
}
