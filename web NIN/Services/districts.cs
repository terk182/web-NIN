using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using web_NIN.Models;

namespace web_NIN.Services
{
    public class districts
    {
        public List<districts_model> get_value(string id)
        {
            var provinces_model_list = new List<districts_model>();

            var txt = new Db_connect();

            using (SqlConnection sqlconn = new SqlConnection(txt.Db_connect_string()))
            {
                sqlconn.Open();
                var sql = "";
                SqlCommand command;
                SqlDataReader dataReader;

                sql = "select * from districts where amphure_id = " + id;
                command = new SqlCommand(sql, sqlconn);
                dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {

                    provinces_model_list.Add(new districts_model
                    {
                        //id = Int32.Parse(dataReader["id"].ToString()),
                        //thai_status = dataReader["thai_status"].ToString(),
                        //eng_status = dataReader["eng_status"].ToString(),
                        id = Int32.Parse(dataReader["id"].ToString()),
                        zip_code = dataReader["zip_code"].ToString(),
                        name_th = dataReader["name_th"].ToString(),
                        name_en = dataReader["name_en"].ToString(),
                        amphure_id = Int32.Parse(dataReader["amphure_id"].ToString()),

                    });
                }


                sqlconn.Close();
            }

            return provinces_model_list;
        }
    }
}
