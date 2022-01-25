using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using web_NIN.Models;

namespace web_NIN.Services
{
    public class agent_data
    {
        public List<agent_model> get_value()
        {
            var customer_list = new List<agent_model>();
            var _customer = new agent_model();
            var txt = new Db_connect();
            // string connection = "Data Source=pro_db.fcc.co.th;Initial Catalog=Nestle;User ID=it_ittipon;Password=@Iet4910751314;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            //string test_db = this.Configuration.GetConnectionString("databaseconnect");
            //var test_db = Configuration.GetConnectionString("databaseconnect");
            using (SqlConnection sqlconn = new SqlConnection(txt.Db_connect_string()))
            {
                sqlconn.Open();
                var sql = "";
                SqlCommand command;
                SqlDataReader dataReader;

                sql = "select * from nin_agent";
                command = new SqlCommand(sql, sqlconn);
                dataReader = command.ExecuteReader();
                int uu = 1;
                while (dataReader.Read())
                {

                    customer_list.Add(new agent_model
                    {
                        remark = (uu++).ToString(),
                        operatorName = dataReader["operatorName"].ToString(),
                        id = (int)dataReader["id"],


                    }); ;
                }


                sqlconn.Close();
            }

            return customer_list;
        }
    }
}
