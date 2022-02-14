using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using web_NIN.Models;

namespace web_NIN.Services
{
    public class get_customer_by_id
    {
        public customer get_value(string id)
        {

            var _customer = new customer();
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

                sql = "select  * from tbNIN_CRM_Outbound where tbCRM_id = '" + id+"'";
                command = new SqlCommand(sql, sqlconn);
                dataReader = command.ExecuteReader();
                int no = 1;
                var count_t = new check_numberOfRepeat();
                while (dataReader.Read())
                {



                    _customer.phone = dataReader["profile_mobile"].ToString();
                    _customer.name = dataReader["profile_firstName"].ToString();
                    _customer.lname = dataReader["profile_lastName"].ToString();


                }


                sqlconn.Close();
            }

            return _customer;
        }
    }
}
