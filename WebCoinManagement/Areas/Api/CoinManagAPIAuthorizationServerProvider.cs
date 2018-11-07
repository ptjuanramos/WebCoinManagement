using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Infrastructure;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using WebCoinManagement.Models;

namespace WebCoinManagement.Areas.Api
{
    public class CoinManagAPIAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated(); 
        }

        public override Task GrantRefreshToken(OAuthGrantRefreshTokenContext context)
        {

            // Change authentication ticket for refresh token requests  
            var newIdentity = new ClaimsIdentity(context.Ticket.Identity);
            newIdentity.AddClaim(new Claim("newClaim", "newValue"));

            var newTicket = new AuthenticationTicket(newIdentity, context.Ticket.Properties);
            context.Validated(newTicket);

            return Task.FromResult<object>(null);

        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {

            var identity = new ClaimsIdentity(context.Options.AuthenticationType);

            using(CoinManagementContext coinManagementContext = new CoinManagementContext())
            {
                var foundUser = coinManagementContext.Users.SingleOrDefault(u => u.Username.Equals(context.UserName));
                if(foundUser != null && foundUser.Password.Equals(context.Password))
                {
                    identity.AddClaim(new Claim(ClaimTypes.Role, foundUser.UserRole));
                    identity.AddClaim(new Claim("username", context.UserName));
                    identity.AddClaim(new Claim(ClaimTypes.Name, context.UserName));
                    context.Validated(identity);
                } else
                {
                    context.SetError("invalid_grant", "Provided username and password is incorrect");
                    return;
                }
            }
        }
    }
}