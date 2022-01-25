using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace web_NIN.Models
{
    public class provinces_model
    {
        public int id { get; set; }
        public string code { get; set; }
        public string name_th { get; set; }
        public string name_en { get; set; }
        public int geography_id { get; set; }
    }
}
