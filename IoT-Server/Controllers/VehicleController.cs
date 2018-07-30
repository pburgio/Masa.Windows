using IoT_Server.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace IoT_Server.Controllers
{
    [RoutePrefix("api/vehicle")]
    public class VehicleController : ApiController
    {
        [Route("pullcmd")]
        [HttpPost]
        [RequireHttps]
        public IHttpActionResult PullCmd()
        {
            return Ok();
        } // PullCmd
    } // class
}// ns
