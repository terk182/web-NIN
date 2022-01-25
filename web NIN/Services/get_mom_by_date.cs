using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using web_NIN.Models;

namespace web_NIN.Services
{
    public class get_mom_by_date
    {
        public List<customer> get_value(string date_)
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


                sql = "SELECT * FROM tbNIN_CRM_Outbound t1  WHERE t1.crm_childBirthDate_used LIKE '%" + date_ + "%' and crm_outboundGroup ='Pregnancy' and data_subscriptions_THnestlegrp_Oonestle_email =1 ";


                command = new SqlCommand(sql, sqlconn);
                dataReader = command.ExecuteReader();
                int no = 1;

                while (dataReader.Read())
                {

                    customer_list.Add(new customer
                    {
                        no = no++,
                        date = dataReader["crm_childBirthDate_used"].ToString(),
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
