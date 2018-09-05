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
        [Route("api/vehicle/{vehicleId}/ctrl")]
        [HttpPost]
        //[Authorize]
        [RequireHttps]
        public IHttpActionResult Ctrl_Post(string vehicleId, [FromBody] string ctrl)
        {
            //if (string.IsNullOrEmpty(ctrl.Key) || !string.Equals("pr0gramm1ng", ctrl.Key))
            //    return Unauthorized();

            //if (semCtrl.ContainsKey(semId))
            //    semCtrl.Remove(semId);
            //semCtrl.Add(semId, ctrl);

            //LogsController.Log("Semaphore '" + semId + "' programmed");

            return Ok();
        } // Ctrl_Post

        public static IDictionary<string, int> vehicleControllers = new Dictionary<string, int>()
        {
            { "car1", -1 }
        };

        [Route("api/vehicle/{vehicleId}/ctrl")]
        [HttpGet]
        [RequireHttps]
        public IHttpActionResult Ctrl_Get(string vehicleId)
        {
            if (string.IsNullOrEmpty(vehicleId))
                return BadRequest();

            if (!vehicleControllers.ContainsKey(vehicleId))
                return Ok(-1);

            var ret = vehicleControllers[vehicleId];

            return Ok(ret);
        } // Ctrl_Get

        [Route("api/vehicle/{vehicleId}/position")]
        [HttpPost]
        [Authorize]
        [RequireHttps]
        public IHttpActionResult Position_Post(string vehicleId, [FromBody] VehiclePosition position)
        {
            if (string.IsNullOrEmpty(vehicleId) || string.IsNullOrEmpty(position.Name))
                return BadRequest();
            

            LogsController.Log("Vehicle '" + vehicleId + "' reported its position at { Lat: " + position.Latitude + 
                " - Lng: " + position.Longitude + " }");

            return Ok();
        } // Position_Post

        [Route("api/vehicle/{vehicleId}/position")]
        [HttpGet]
        [RequireHttps]
        public IHttpActionResult Position_Get(string vehicleId, [FromBody] string ctrl)
        {
            //if (string.IsNullOrEmpty(ctrl.Key) || !string.Equals("pr0gramm1ng", ctrl.Key))
            //    return Unauthorized();

            //if (semCtrl.ContainsKey(semId))
            //    semCtrl.Remove(semId);
            //semCtrl.Add(semId, ctrl);

            //LogsController.Log("Semaphore '" + semId + "' programmed");

            return Ok();
        } // Position_Get
    } // class
}// ns
