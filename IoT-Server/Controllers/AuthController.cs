using IoT_Server.Helpers;
using IoT_Server.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace IoT_Server.Controllers
{
    public class AuthController : ApiController
    {
        [Route("api/tokens")]
        [HttpPost]
        [RequireHttps]
        public IHttpActionResult Post([FromBody] TokenChallenge challenge)
        {
            var enabled = false;
            bool.TryParse(ConfigurationManager.AppSettings["TokensEpEnabled"], out enabled);

            if(!enabled)
            {
                return NotFound();
            }

            var secret = ConfigurationManager.AppSettings["TokensSecret"];
            var expiration = 365;
            if (challenge == null ||
                string.IsNullOrEmpty(challenge.UserId) ||
                string.IsNullOrEmpty(challenge.Secret) ||
                !string.Equals(challenge.Secret, secret))
                return Unauthorized();

            var token = AuthUtils.CreateToken(challenge.UserId, TimeSpan.FromDays(expiration));
                
            return Ok(token.RawData);
        } // ReportStatus
    } // AuthController
} // ns
