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
    [RoutePrefix("api/pages")]
    public class PagesController : ApiController
    {
        [Route("getlogs")]
        [HttpPost]
        [RequireHttps]
        public IHttpActionResult GetLogs()
        {
            var ret = new ListResponse();
            for (int i = 0; i < 20; i++)
                ret.Rows.Add("[" + DateTime.Now + "] Log #" + i);
            return Ok(ret);
        } // ReportState
    }
}
