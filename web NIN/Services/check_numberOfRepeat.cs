using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace web_NIN.Services
{
    public class check_numberOfRepeat
    {

        public int get_value(string customer_id)
        {
            Int32 count = 0;
            var txt = new Db_connect();
            using (SqlConnection sqlconn = new SqlConnection(txt.Db_connect_string()))
            {
                sqlconn.Open();

                SqlCommand command;
                SqlDataReader dataReader;
                String sql;
                sql = "select * from nin_survey_log where custommerID = '"+ customer_id+"'";
                command = new SqlCommand(sql, sqlconn);
                dataReader = command.ExecuteReader();

              
                while (dataReader.Read())
                {

                    count++;
                }

            }
            return count;
        }
    }
}
