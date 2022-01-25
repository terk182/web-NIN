using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using web_NIN.Models;

namespace web_NIN.Services
{
    public class update_agent_id_to_custommer
    {
        public bool set_value(List<RequestObj> data_model,string agent_id)
        {
            var txt = new Db_connect();
           
            using (SqlConnection sqlconn = new SqlConnection(txt.Db_connect_string()))
            {

                var sql = "";
                SqlCommand command;


                //sql = "insert into dbo.nin_assign (create_date, create_time, create_operator_name, operatorID,custommerID,customer_name,phone,status ) values ";
                sql = "update dbo.tbNIN_CRM_Outbound SET agent_id = '";
                sql += agent_id;
                sql += "' where tbCRM_id IN";

                var sql_value = "";
                for (int i = 0; i < data_model.Count; i++)
                {
                 
                    sql_value += ",'" + data_model[i].custommerID + "'";


                    //command.Parameters.AddWithValue("@create_operator_name", data_model[i].custommer_name);
                    //command.Parameters.AddWithValue("@operatorID", data_model[i].operatorID);
                    //command.Parameters.AddWithValue("@custommerID", data_model[i].custommerID);
                    //command.Parameters.AddWithValue("@customer_name", data_model[i].custommer_name);




                }
                sql = sql+"("+sql_value.Substring(1)+")";
                command = new SqlCommand(sql, sqlconn);
                sqlconn.Open();
                command.ExecuteNonQuery();




                return true;
            }

        }
    }
}
