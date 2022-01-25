using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using web_NIN.Models;

namespace web_NIN.Services
{
    public class agent_service
    {
        public List<agent_model> get_value(string name)
        {
            var Status_call_list = new List<agent_model>();
            
            var txt = new Db_connect();

            using (SqlConnection sqlconn = new SqlConnection(txt.Db_connect_string()))
            {
                sqlconn.Open();
                var sql = "";
                SqlCommand command;
                SqlDataReader dataReader;

                sql = "select * from nin_agent where operatorName = '" + name+"'";
                command = new SqlCommand(sql, sqlconn);
                dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {

                    Status_call_list.Add(new agent_model
                    {
                        
                        operatorName = dataReader["operatorName"].ToString(),
                       

                    });
                }


                sqlconn.Close();
            }

            return Status_call_list;
        }
    }
}
