using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore.Web.Models
{
    public class Response
    {
        public bool Status { get; set; }

        public string Message { get; set; }

        public dynamic Data { get; set; }
    }
}
