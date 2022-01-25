using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using web_NIN.Models;

namespace web_NIN.Services
{
    public class type_of_milk
    {
        public List<Status_call_model> get_type_milk()
        {
            var Status_call_list = new List<Status_call_model>();
            var _Status_call = new Status_call_model();
            var txt = new Db_connect();

            using (SqlConnection sqlconn = new SqlConnection(txt.Db_connect_string()))
            {
                sqlconn.Open();
                var sql = "";
                SqlCommand command;
                SqlDataReader dataReader;

                sql = "select * from type_of_milk_to_drink";
                command = new SqlCommand(sql, sqlconn);
                dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {

                    Status_call_list.Add(new Status_call_model
                    {
                        id = Int32.Parse(dataReader["id"].ToString()),
                        thai_status = dataReader["thai_status"].ToString(),
                        eng_status = dataReader["eng_status"].ToString(),

                    });
                }


                sqlconn.Close();
            }

            return Status_call_list;
        }
    }
}
