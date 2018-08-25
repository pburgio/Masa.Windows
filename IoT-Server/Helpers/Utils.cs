using System;
using System.Configuration;
using System.IdentityModel.Tokens;
using System.Security.Claims;

namespace IoT_Server.Helpers
{
    public class AuthUtils
    {
        public static JwtSecurityToken CreateToken(string userId, TimeSpan? lifetime)
        {
            var signingKey = ConfigurationManager.AppSettings["SigningKey"];
            var audience = ConfigurationManager.AppSettings["ValidAudience"];
            var issuer = ConfigurationManager.AppSettings["ValidIssuer"];
            var claims = new Claim[]
            {
                new Claim(JwtRegisteredClaimNames.UniqueName, userId), // This will be User.Identity.Name
                new Claim(JwtRegisteredClaimNames.Sub, userId) // Mandatory
            };

            var azureToken = Microsoft.Azure.Mobile.Server.Login.
                AppServiceLoginHandler.CreateToken(claims, signingKey, audience, issuer, lifetime);
            return azureToken;
        }
    } // AuthUtils
} // ns