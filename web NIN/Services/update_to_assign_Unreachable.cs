using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using web_NIN.Models;

namespace web_NIN.Services
{
    public class update_to_assign_Unreachable
    {
        public bool set_value(List<RequestObj> data_model)
        {
            var txt = new Db_connect();

            using (SqlConnection sqlconn = new SqlConnection(txt.Db_connect_string()))
            {

                var sql = "";
                SqlCommand command;
                //var date_ = DateTime.Now.ToString("yyyy-MM-dd");
                //var time_ = DateTime.Now.ToString("HH:mm:ss");

                //sql = "insert into dbo.nin_assign (create_date, create_time, create_operator_name, operatorID,custommerID,customer_name,phone,status ) values ";
                // sql = "update dbo.nin_assign SET  update_date = '" + date_ + "', update_time = '" + time_ + "', update_operator_name = '" + data_model[0].create_operator_name + "', operatorID = ";
                sql = "update dbo.nin_assign SET second = '"+ data_model[0].replece + "'";

                sql += " where custommerID IN";

                var sql_value = "";
                for (int i = 0; i < data_model.Count; i++)
                {

                    sql_value += ",'" + data_model[i].custommerID + "'";


                    //command.Parameters.AddWithValue("@create_operator_name", data_model[i].custommer_name);
                    //command.Parameters.AddWithValue("@operatorID", data_model[i].operatorID);
                    //command.Parameters.AddWithValue("@custommerID", data_model[i].custommerID);
                    //command.Parameters.AddWithValue("@customer_name", data_model[i].custommer_name);




                }
                sql = sql + "(" + sql_value.Substring(1) + ")";
                command = new SqlCommand(sql, sqlconn);
                sqlconn.Open();
                command.ExecuteNonQuery();




                return true;
            }

        }
    }
}
