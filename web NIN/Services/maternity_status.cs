using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using web_NIN.Models;

namespace web_NIN.Services
{
    public class maternity_status
    {
        public List<maternity_status_model> get_maternity_status()
        {
            var maternity_list = new List<maternity_status_model>();
            
            var txt = new Db_connect();

            using (SqlConnection sqlconn = new SqlConnection(txt.Db_connect_string()))
            {
                sqlconn.Open();
                var sql = "";
                SqlCommand command;
                SqlDataReader dataReader;

                sql = "select * from maternity_status";
                command = new SqlCommand(sql, sqlconn);
                dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {

                    maternity_list.Add(new maternity_status_model
                    {
                        id = Int32.Parse(dataReader["id"].ToString()),
                        thai_status = dataReader["thai_status"].ToString(),
                        eng_status = dataReader["eng_status"].ToString(),

                    });
                }


                sqlconn.Close();
            }

            return maternity_list;
        }
    }
}
