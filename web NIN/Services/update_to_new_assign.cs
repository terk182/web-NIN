using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace web_NIN.Services
{
    public class update_to_new_assign
    {
        public bool set_value(string agent_id, string customer_id,string update_operator_name)
        {
            var txt = new Db_connect();

            using (SqlConnection sqlconn = new SqlConnection(txt.Db_connect_string()))
            {

                var sql = "";
                SqlCommand command;
               var date_ = DateTime.Now.ToString("yyyy-MM-dd");
               var time_ =  DateTime.Now.ToString("HH:mm:ss");

                //sql = "insert into dbo.nin_assign (create_date, create_time, create_operator_name, operatorID,custommerID,customer_name,phone,status ) values ";
                sql = "update dbo.nin_assign SET update_date = '" + date_ + "', update_time = '"+ time_ + "', update_operator_name = '"+ update_operator_name + "',operatorID = '" + agent_id + "' where custommerID = '" + customer_id + "'";


                command = new SqlCommand(sql, sqlconn);
                sqlconn.Open();
                command.ExecuteNonQuery();




                return true;
            }

        }
    }
}
