using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace web_NIN.Services
{
    public class update_custmor_new_agent
    {
        public bool set_value(string agent_id, string customer_id)
        {
            var txt = new Db_connect();

            using (SqlConnection sqlconn = new SqlConnection(txt.Db_connect_string()))
            {

                var sql = "";
                SqlCommand command;


                //sql = "insert into dbo.nin_assign (create_date, create_time, create_operator_name, operatorID,custommerID,customer_name,phone,status ) values ";
                sql = "update dbo.tbNIN_CRM_Outbound SET agent_id = '"+ agent_id + "' where tbCRM_id = '" + customer_id + "'";


                command = new SqlCommand(sql, sqlconn);
                sqlconn.Open();
                command.ExecuteNonQuery();




                return true;
            }

        }
    }
}
