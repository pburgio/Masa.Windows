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
    public class VehicleController : ApiController
    {
        protected static IDictionary<string, VehicleCtrl> vehicleCtrl = new Dictionary<string, VehicleCtrl>();
        protected static IDictionary<string, Position> knownVehiclePositions = new Dictionary<string, Position>()
        {
            { "prova1", new Position { Latitude = 0.0, Longitude = 1.0} },
            { "prova2", new Position { Latitude = 2.0, Longitude = 3.0} }
        };

        [Route("api/vehicle/{vehicleId}/ctrl")]
        [HttpPost]
        //[Authorize]
        [RequireHttps]
        public IHttpActionResult Ctrl_Post(string vehicleId, [FromBody] VehicleCtrl ctrl)
        {
            if (string.IsNullOrEmpty(ctrl.Key) || !string.Equals("pr0gramm1ng", ctrl.Key))
                return Unauthorized();

            if (vehicleCtrl.ContainsKey(vehicleId))
                vehicleCtrl.Remove(vehicleId);

            ctrl.Key = string.Empty; // Not to shout our pwd all around the world...
            vehicleCtrl.Add(vehicleId, ctrl);

            LogsController.Log("Vehicle '" + vehicleId + "' will go to path '" + ctrl.Path + "'");

            return Ok();
        } // Ctrl_Post
        
        [Route("api/vehicle/{vehicleId}/ctrl")]
        [HttpGet]
        [RequireHttps]
        public IHttpActionResult Ctrl_Get(string vehicleId, [FromUri] Position position)
        {
            if (string.IsNullOrEmpty(vehicleId))
                return BadRequest();

            ReportPosition(vehicleId, position);

            if (!vehicleCtrl.ContainsKey(vehicleId))
                return Ok(new VehicleCtrl()
                {
                    Path = -1
                });

            var ret = vehicleCtrl[vehicleId];
            ret.Name = "";
            ret.Key = "";
            return Ok(ret);
        } // Ctrl_Get

        private void ReportPosition(string vehicleId, Position position)
        {
            if (knownVehiclePositions.ContainsKey(vehicleId))
                knownVehiclePositions.Remove(vehicleId);
            knownVehiclePositions.Add(vehicleId, position);

            //LogsController.Log("Vehicle '" + vehicleId + "' reported its position at { Lat: " + position.Latitude + " - Lng: " + position.Longitude + " }");
            // TODO to test
        }

        [Route("api/vehicle/{vehicleId}/position")]
        [HttpPost]
        //[Authorize]
        [RequireHttps]
        public IHttpActionResult Position_Post(string vehicleId, [FromUri] Position position)
        {
            if (string.IsNullOrEmpty(vehicleId))
                return BadRequest();

            ReportPosition(vehicleId, position);

            return Ok();
        } // Position_Post

        [Route("api/vehicle/all/position")]
        [HttpGet]
        [RequireHttps]
        public IHttpActionResult GetAll()
        {
            return Ok(VehiclePosition.FromDictionary(knownVehiclePositions));
        } // Position_Get

        [Route("api/vehicle/{vehicleId}/position")]
        [HttpGet]
        [RequireHttps]
        public IHttpActionResult Position_Get(string vehicleId, [FromBody] string ctrl)
        {
            //if (string.IsNullOrEmpty(ctrl.Key) || !string.Equals("pr0gramm1ng", ctrl.Key))
            //    return Unauthorized();

            if (!knownVehiclePositions.ContainsKey(vehicleId))
                return Ok();

            var pos = knownVehiclePositions[vehicleId];
            var ret = new VehiclePosition()
            {
                Name = vehicleId,
                Position = pos
            };
            return Ok(ret);
        } // Position_Get
    } // class
}// ns
