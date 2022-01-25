using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace web_NIN.Models
{
    public class districts_model
    {
        public int id { get; set; }
        public string zip_code { get; set; }
        public string name_th { get; set; }
        public string name_en { get; set; }
        public int amphure_id { get; set; }
    }
}
