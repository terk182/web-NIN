using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using web_NIN.Models;

namespace web_NIN.Services
{
    public class insert_agent
    {
        public bool set_value(agent_model Agent_model)
        {
            var txt = new Db_connect();

            using (SqlConnection sqlconn = new SqlConnection(txt.Db_connect_string()))
            {

                var sql = "";
                SqlCommand command;


                sql = @"insert into dbo.nin_agent ( create_operator_name, operatorName)
                       values ( @create_operator_name, @operatorName)";
                command = new SqlCommand(sql, sqlconn);

                command.Parameters.AddWithValue("@create_operator_name", Agent_model.create_operator_name);
                command.Parameters.AddWithValue("@operatorName", Agent_model.operatorName);
 

                sqlconn.Open();
                command.ExecuteNonQuery();

                return true;
            }

        }
    }
}
