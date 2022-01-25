using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using web_NIN.Models;

namespace web_NIN.Services
{
    public class between_assign_id
    {
        public List<assign_model> get_value( string min_u, string max_u)
        {
            var customer_list = new List<assign_model>();
            var _customer = new assign_model();
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
                sql = "SELECT t1.create_date,t2.profile_firstName,t2.profile_lastName,t2.profile_mobile,t2.profile_email,t1.operatorID,t2.status as status_mom,t2.update_status,t1.numberOfRepeat,t1.status AS status_m_agent,t1.statusOfCase,t2.tbCRM_id FROM nin_assign t1 LEFT JOIN tbNIN_CRM_Outbound t2 ON t2.tbCRM_id = t1.custommerID WHERE t1.operatorID between '"+ min_u + "' and '"+ max_u+"'";

                command = new SqlCommand(sql, sqlconn);
                dataReader = command.ExecuteReader();
                int no = 1;

                while (dataReader.Read())
                {

                    customer_list.Add(new assign_model
                    {
                        date = dataReader["create_date"].ToString(),
                        mom_name = dataReader["profile_firstName"].ToString(),
                        mom_lname = dataReader["profile_firstName"].ToString(),
                        phone = dataReader["profile_mobile"].ToString(),
                        email = dataReader["profile_email"].ToString(),
                        agent_id = dataReader["operatorID"].ToString(),
                        status = dataReader["status_m_agent"].ToString(),
                        statusOfCase = dataReader["statusOfCase"].ToString(),
                        custommerID = dataReader["tbCRM_id"].ToString(),
                        numberOfRepeat = dataReader["numberOfRepeat"].ToString(),
                    });
                }


                sqlconn.Close();
            }

            return customer_list;
        }
    }
}
