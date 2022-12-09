using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Borito.WEB.SD;

namespace Borito.WEB.Models
{
    public class ApiRequest
    {
        public ApiType apiType { get; set; }
        public string Url { get; set; }
        public object Data { get; set; }
        public string AccessToken { get; set; }
    }
}
