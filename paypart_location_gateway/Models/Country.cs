using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace paypart_location_gateway.Models
{
    public class Country
    {
        public int id { get; set; }
        public string code { get; set; }
        public string title { get; set; }
        public int status { get; set; }
        public DateTime created_on { get; set; }
    }
}
