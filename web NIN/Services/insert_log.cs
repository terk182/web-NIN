using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using web_NIN.Models;

namespace web_NIN.Services
{
    public class insert_log
    {

        public bool set_value(Logmodel Logmodel)
        {
            var txt = new Db_connect();

            using (SqlConnection sqlconn = new SqlConnection(txt.Db_connect_string()))
            {
                
                var sql = "";
                SqlCommand command;
               

                sql = @"insert into dbo.nin_survey_log (create_date, create_time, create_operator_name, create_operator_id, operatorID, custommerID, acton,status,datail,numberOfRepeat)
                       values (@create_date, @create_time, @create_operator_name, @create_operator_id, @operatorID, @custommerID, @acton, @status, @datail, @numberOfRepeat)";
                command = new SqlCommand(sql, sqlconn);
                command.Parameters.AddWithValue("@create_date", DateTime.Now.ToString("yyyy-MM-dd"));
                command.Parameters.AddWithValue("@create_time", DateTime.Now.ToString("HH:mm:ss"));
                command.Parameters.AddWithValue("@create_operator_name", Logmodel.operatorID);
                command.Parameters.AddWithValue("@create_operator_id", "");
                command.Parameters.AddWithValue("@operatorID", Logmodel.operatorID);
                command.Parameters.AddWithValue("@custommerID", Logmodel.custommerID);
                command.Parameters.AddWithValue("@acton", Logmodel.acton);
                command.Parameters.AddWithValue("@status", Logmodel.status);
                command.Parameters.AddWithValue("@datail", Logmodel.datail);
                command.Parameters.AddWithValue("@numberOfRepeat", Logmodel.numberOfRepeat);

                sqlconn.Open();
                command.ExecuteNonQuery();
                
                return true;
            }

        }


    }
}
