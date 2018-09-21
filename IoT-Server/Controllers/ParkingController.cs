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
    public class ParkingController : ApiController
    {
        [Route("api/parking/{vehicleId}")]
        [HttpGet]
        [RequireHttps]
        public IHttpActionResult Parking_Get([FromUri] Position request)
        {
            var response = new Position()
            {
                Latitude = double.Parse(ConfigurationManager.AppSettings["ParkingLat"]),
                Longitude = double.Parse(ConfigurationManager.AppSettings["ParkingLng"])
            };
            return Ok(response);
        }

        [Route("api/parking/{vehicleId}")]
        [HttpPost]
        [RequireHttps]
        //[Authorize]
        public IHttpActionResult Parking_Post(string vehicleId, [FromUri] Position position)
        {
            LogsController.Log("Vehicle '" + vehicleId + "' booked parking at { Lat: " + position.Latitude + " - Lng: " + position.Longitude + " }");
            return Ok();
        }

        [Route("api/parking/{vehicleId}/release")]
        [HttpPost]
        //[HttpDelete] This does not work...
        [RequireHttps]
        //[Authorize]
        public IHttpActionResult Parking_Delete(string vehicleId, [FromUri] Position position)
        {
            LogsController.Log("Vehicle '" + vehicleId + "' released parking at { Lat: " + position.Latitude + " - Lng: " + position.Longitude + " }");
            return Ok();
        }
    } // class
} // ns
