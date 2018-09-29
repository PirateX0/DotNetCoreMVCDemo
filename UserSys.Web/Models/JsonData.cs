using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserSys.Web.Models
{
    public class JsonData
    {
        public string Status { get; set; }
        public string Msg { get; set; }
        public object Data { get; set; }
    }
}
