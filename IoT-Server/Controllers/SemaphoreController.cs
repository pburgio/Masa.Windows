using IoT_Server.Helpers;
using IoT_Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace IoT_Server.Controllers
{
    //[RoutePrefix("api/semaphore")]
    public class SemaphoreController : ApiController
    {
        [Route("api/semaphore/{semaphoreId}")]
        [HttpPost]
        [RequireHttps]
        [Authorize]
        public IHttpActionResult ReportStatus(string semaphoreId, [FromBody] SemaphoreStatus body)
        {
            if (User == null || User.Identity == null || string.IsNullOrEmpty(User.Identity.Name))
                return Unauthorized();
            var userId = User.Identity.Name; // sem1

            return Ok("ciao");
        } // ReportStatus

        //[Route("api/semaphore/{semaphoreId}")]
        //[HttpGet]
        //[RequireHttps]
        //public IHttpActionResult GetStatus(string semaphoreId)
        //{
        //    return Ok();
        //} // GetStatus

        [Route("pullcmd")]
        [HttpPost]
        [RequireHttps]
        public IHttpActionResult PullCmd()
        {
            return Ok();
        } // PullCmd

    } // class
} // ns
