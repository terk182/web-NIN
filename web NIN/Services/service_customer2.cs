using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using web_NIN.Models;

namespace web_NIN.Services
{
    public class service_customer2
    {





        public List<customer> get_customer(string agen_id)
        {
            var customer_list = new List<customer>();

            var customer_list_check = new List<customer>();
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

            

                sql = "SELECT t2.tbGigya_registerDate,t2.profile_firstName,t2.profile_lastName,t2.profile_mobile,t2.profile_email,t2.tbCRM_id,t1.reason from nin_assign_second t1 LEFT join tbNIN_CRM_Outbound t2 ON t2.tbCRM_id = t1.custommerID   WHERE t1.status != 'Complete' and  t1.operatorID ='" + agen_id + "'";
                command = new SqlCommand(sql, sqlconn);
                dataReader = command.ExecuteReader();
                int no = 1;
                var count_t = new check_numberOfRepeat();
                var _get_log = new get_log();
                var bbb = 0;
                var txt_r = "";
                var txt_x = "";
                var idd = "";







                while (dataReader.Read())
                {
                    idd = dataReader["tbCRM_id"].ToString();
                    bbb = count_t.get_value(dataReader["tbCRM_id"].ToString());
                    if (true)
                    {

                        var txt_rR = _get_log.get_value(idd);
                        if (txt_rR.Count > 0)
                        {
                            txt_r = _get_log.get_value(dataReader["tbCRM_id"].ToString())[^1].status;
                            txt_x = _get_log.get_value(dataReader["tbCRM_id"].ToString())[^1].datail;
                        }
                        else
                        {
                            txt_r = "pending";
                            txt_x = "";
                        }
                        customer_list.Add(new customer
                        {
                            no = no++,
                            date = dataReader["tbGigya_registerDate"].ToString(),
                            name = dataReader["profile_firstName"].ToString(),
                            lname = dataReader["profile_lastName"].ToString(),
                            phone = dataReader["profile_mobile"].ToString(),
                            email = dataReader["profile_email"].ToString(),
                            replace = bbb.ToString(),

                            case_no = txt_r,
                            detail = txt_x,
                            status = txt_r,
                            customer_id = dataReader["tbCRM_id"].ToString(),
                            catagory = dataReader["reason"].ToString()
                        });
                    }

                }
                no = 1;
                foreach (var value in customer_list)
                {
                    
                        customer_list_check.Add(new customer
                        {
                            no = no++,
                            date = value.date,
                            name = value.name,
                            lname = value.lname,
                            phone = value.phone,
                            email = value.email,
                            replace = value.replace,

                            case_no = value.case_no,
                            detail = value.detail,
                            status = value.status,
                            customer_id = value.customer_id,
                            catagory = value.catagory
                        });
                    
                }
                







                sqlconn.Close();
            }
          






            return customer_list_check;
        }
    }
}
