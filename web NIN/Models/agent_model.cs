using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace web_NIN.Models
{
    public class agent_model
    {

        public int id { get; set; }
        public DateTime create_date { get; set; }
        public DateTime create_time { get; set; }
        public string create_operator_name { get; set; }
        public string create_operator_id { get; set; }
        public string remark { get; set; }
        public string operatorID { get; set; }
        public string operatorName { get; set; }
        public string active { get; set; }
       
    }
}
