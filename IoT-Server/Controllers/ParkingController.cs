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
    public class ParkingController : ApiController
    {
        [Route("api/parking")]
        [HttpGet]
        [RequireHttps]
        public IHttpActionResult Parking_Get(double lat, double lng, string vehicleId)
        {
            var response = new Position()
            {
                Latitude = 1.12,
                Longitude = 4.56
            };
            return Ok(response);
        }

        [Route("api/parking")]
        [HttpPost]
        [RequireHttps]
        //[Authorize]
        public IHttpActionResult Parking_Post([FromBody] VehiclePosition request)
        {
            // TODO check auth
            VehicleController.vehicleControllers[request.Name] = 6;
            return Ok();
        }
    } // class
} // ns
