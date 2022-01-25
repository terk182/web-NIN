using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using web_NIN.Models;

namespace web_NIN.Services
{
    public class insert_backup
    {

        public bool set_value(buckup_model Buckup_model)
        {
            var txt = new Db_connect();

            using (SqlConnection sqlconn = new SqlConnection(txt.Db_connect_string()))
            {

                var sql = "";
                SqlCommand command;


                sql = @"insert into dbo.nin_backup_customer_data (create_date, create_time, create_operator_name, data_value,row_id)
                       values (@create_date, @create_time, @create_operator_name, @data_value,@row_id)";
                command = new SqlCommand(sql, sqlconn);
                command.Parameters.AddWithValue("@create_date", DateTime.Now.ToString("yyyy-MM-dd"));
                command.Parameters.AddWithValue("@create_time", DateTime.Now.ToString("HH:mm:ss"));
                command.Parameters.AddWithValue("@create_operator_name", Buckup_model.create_operator_name);
                command.Parameters.AddWithValue("@data_value", Buckup_model.data_value);
                command.Parameters.AddWithValue("@row_id", Buckup_model.row_id);


                sqlconn.Open();
                command.ExecuteNonQuery();

                return true;
            }

        }
    }
}
