using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using web_NIN.Models;

namespace web_NIN.Services
{
    public class agent_service_by_id
    {
      
            public List<assign_model> get_value(string id)
            {
                var Status_call_list = new List<assign_model>();

                var txt = new Db_connect();

                using (SqlConnection sqlconn = new SqlConnection(txt.Db_connect_string()))
                {
                    sqlconn.Open();
                    var sql = "";
                    SqlCommand command;
                    SqlDataReader dataReader;

                    sql = "select * from nin_assign where operatorID = '" + id + "'";
                    command = new SqlCommand(sql, sqlconn);
                    dataReader = command.ExecuteReader();
                var ii = 1;
                    while (dataReader.Read())
                    {

                        Status_call_list.Add(new assign_model
                        {
                            no = ii++,
                            date = dataReader["create_date"].ToString(),
                            mom_name = dataReader["customer_name"].ToString(),
                            status = dataReader["status"].ToString(),
                            numberOfRepeat = dataReader["numberOfRepeat"].ToString(),
                            //operatorName = dataReader["operatorName"].ToString(),
                            //create_date == (DateTime)dataReader["create_date"],

                        });
                    }


                    sqlconn.Close();
                }

                return Status_call_list;
            }
        
    }
}