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
    public class LogsController : ApiController
    {
        protected static long maxLogs = 10;
        protected static IList<string> logs = new List<string>();

        public static void Log(string str)
        {
            if (logs.Count >= maxLogs)
                logs.RemoveAt(logs.Count - 1);
            logs.Insert(0,"[" + DateTime.Now + "] " + str);
        }

        [Route("api/logs")]
        [HttpGet]
        [RequireHttps]
        public IHttpActionResult GetLogs()
        {
            return Ok(logs);
        } // ReportState
    }
}
