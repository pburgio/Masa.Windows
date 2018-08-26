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
        [Route("api/semaphore/{semaphoreId}/status")]
        [HttpPost]
        [RequireHttps]
        [Authorize]
        public IHttpActionResult Status_Post(string semaphoreId, [FromBody] SemaphoreStatus body)
        {
            if (User == null || User.Identity == null || string.IsNullOrEmpty(User.Identity.Name))
                return Unauthorized();
            var userId = User.Identity.Name; // sem1

            return Ok("POST RESPONSE @" + DateTime.Now);
        } // Status_Post

        [Route("api/semaphore/{semaphoreId}/status")]
        [HttpGet]
        [RequireHttps]
        public IHttpActionResult Status_Get(string semaphoreId)
        {
            return Ok("GET RESPONSE @" + DateTime.Now);
        } // GetStatus

        [Route("api/semaphore/{semaphoreId}/cmd")]
        [HttpGet]
        [RequireHttps]
        public IHttpActionResult Cmd()
        {
            return Ok();
        } // Cmd

    } // class
} // ns
