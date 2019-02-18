using System;
using NavTech.Services;
using Microsoft.Owin.Security;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Owin.Security.OAuth;
using System.Security;

namespace NavTech.Providers
{
    public class OAuthProvider :  OAuthAuthorizationServerProvider
    {
        public override Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            return Task.Factory.StartNew(() =>
            {
                var username = context.UserName;
                var password = context.Password;
                var userService = new UserService();

                var user = userService.ValidateUser(username, password);

                if(user!=null)
                {
                    var claims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.Sid,Convert.ToString(user.Id)),
                        new Claim(ClaimTypes.Name, user.Name),
                        new Claim(ClaimTypes.Email,user.Email),
                        new Claim(ClaimTypes.Role,user.Role)
                    };

                    //foreach (var role in user.Role)
                    //    claims.Add(new Claim(ClaimTypes.Role , role ));

                    ClaimsIdentity oAuthIdentity= new ClaimsIdentity(claims, Startup.OAuthOptions.AuthenticationType);

                    var properties = CreateProperties(user.Name);
                    var ticket = new AuthenticationTicket(oAuthIdentity, properties);
                    context.Validated(ticket);


                }
                else
                {
                    context.SetError("invalid_grant","Username Or Password Incorrect");
                }


            });
            
        }
        // end region


        //validate Client Authentication

        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            if (context.ClientId == null)
                context.Validated();

            return Task.FromResult<object>(null);
            
        }

        //Token EndPoint


        public override Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
           foreach(KeyValuePair<string,string> property in context.Properties.Dictionary)
            {
                context.AdditionalResponseParameters.Add(property.Key, property.Value);
            }
            return Task.FromResult<object>(null);

        }


        // create properties 

        public static AuthenticationProperties CreateProperties(string username)
        {
            IDictionary<string, string> data = new Dictionary<string, string>
            {
                {"username",username }
            };

            return new AuthenticationProperties(data);

        }
        
    }
}