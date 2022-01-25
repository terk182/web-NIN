using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace web_NIN.Models
{
    public class Logmodel
    {
        public DateTime create_date { get; set; }
        public DateTime create_time { get; set; }
        public string create_operator_name { get; set; }
        public string create_operator_id { get; set; }
        public DateTime update_date { get; set; }
        public DateTime update_time { get; set; }
        public string update_operator_name { get; set; }
        public string update_operator_id { get; set; }
        public string remark { get; set; }
        public string operatorID { get; set; }
        public string custommerID { get; set; }
        public string acton { get; set; }
        public string status { get; set; }
        public string datail { get; set; }
        public string result { get; set; }
        public int numberOfRepeat { get; set; }
        public string type { get; set; }
    }
}
