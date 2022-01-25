using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace web_NIN.Services
{
    public class update_to_assign
    {
        public bool set_value(string command_sql)
        {
            var txt = new Db_connect();

            using (SqlConnection sqlconn = new SqlConnection(txt.Db_connect_string()))
            {

                var sql = command_sql;
                SqlCommand command;



                command = new SqlCommand(sql, sqlconn);


                sqlconn.Open();
                command.ExecuteNonQuery();

                return true;
            }

        }
    }
}
