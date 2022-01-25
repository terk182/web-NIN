using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using web_NIN.Models;

namespace web_NIN.Services
{
    public class between_find
    {
        public List<customer> get_customer(string command_u,string min_u,string max_u)
        {
            var customer_list = new List<customer>();
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
                if(command_u == "id")
                {
                    sql = "select * from tbNIN_CRM_Outbound where tbCRM_id between '"+ min_u+"' and '"+ max_u+ "' ORDER BY tbCRM_id ASC";
                }
                else
                {
                    sql = "select * from tbNIN_CRM_Outbound where tbGigya_registerDate between '" + min_u + "' and '" + max_u + "' ORDER BY tbCRM_id ASC";
                }
                
                command = new SqlCommand(sql, sqlconn);
                dataReader = command.ExecuteReader();
                int no = 1;
              
                while (dataReader.Read())
                {

                    customer_list.Add(new customer
                    {
                        no = no++,
                        date = dataReader["tbGigya_registerDate"].ToString(),
                        name = dataReader["profile_firstName"].ToString(),
                        lname = dataReader["profile_lastName"].ToString(),
                        phone = dataReader["profile_mobile"].ToString(),
                        email = dataReader["profile_email"].ToString(),
                        replace = "",
                        case_no = "Active",
                        status = "",
                        customer_id = dataReader["tbCRM_id"].ToString(),
                        agent_id = dataReader["agent_id"].ToString(),

                    });
                }


                sqlconn.Close();
            }

            return customer_list;
        }
    }
}
