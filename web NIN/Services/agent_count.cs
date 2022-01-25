using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using web_NIN.Models;

namespace web_NIN.Services
{
    public class agent_count
    {
        public customer_count_model count_agent()
        {

            var _customer = new customer_count_model();
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

                sql = "select count(*) as rowdata from nin_agent";
                command = new SqlCommand(sql, sqlconn);
                dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {



                    _customer.row_data = (Int32)dataReader["rowdata"];

                }


                sqlconn.Close();
            }

            return _customer;
        }
    }
}
