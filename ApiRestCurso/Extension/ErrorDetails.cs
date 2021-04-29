using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRestCurso.Extension
{
    public class ErrorDetails
    {
        public int Statuscode { get; set; }

        public string Message { get; set; }

        public string Trace { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

}
