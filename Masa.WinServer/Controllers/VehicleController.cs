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
    public class VehicleController : ApiController
    {
        protected static IDictionary<string, VehicleCtrl> vehicleCtrl = new Dictionary<string, VehicleCtrl>();
        protected static IDictionary<string, Position> knownVehiclePositions = new Dictionary<string, Position>()
        {
            { "FakeVehicle1", new Position { Latitude = 1.1, Longitude = 10.10} },
            { "FakeVehicle2", new Position { Latitude = 2.2, Longitude = 20.20} }
        };

        [Route("api/vehicle/{vehicleId}/ctrl")]
        [HttpPost]
        //[Authorize]
        [RequireHttps]
        public IHttpActionResult Ctrl_Post(string vehicleId, [FromBody] VehicleCtrl ctrl)
        {
            if (string.IsNullOrEmpty(ctrl.Key) || !string.Equals(ConfigurationManager.AppSettings["Key"], ctrl.Key))
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

        IDictionary<string, string> knownVehicles = new Dictionary<string, string>()
        {
            { "car1", "Maserati 4porte (HiPeRT)" },
            { "diogene", "Droid (Lifetouch)" },
        };

        [Route("api/vehicle/{vehicleId}/position")]
        [HttpGet]
        [RequireHttps]
        public IHttpActionResult Position_Get(string vehicleId, [FromBody] string ctrl)
        {

            if (!knownVehiclePositions.ContainsKey(vehicleId))
                return Ok();

            var pos = knownVehiclePositions[vehicleId];

            var ret = new VehiclePosition()
            {
                FriendlyName = knownVehicles.ContainsKey(vehicleId) ? knownVehicles[vehicleId] : vehicleId,
                Name = vehicleId,
                Position = pos
            };
            return Ok(ret);
        } // Position_Get
    } // class
}// ns
