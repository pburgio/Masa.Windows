using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IoT_Server.Models
{
    public class ListResponse
    {
        public IList<string> Rows { get; set; }

        public ListResponse()
        {
            this.Rows = new List<string>();
        }
    }
}