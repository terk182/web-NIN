using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using web_NIN.Models;

namespace web_NIN.Services
{
    public class get_mom_date
    {
        public mom_date_model get_mom_date_t(string sdate)
        {

            var _mom_date = new mom_date_model();
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

                sql = "Select (DATEDIFF(day,dateadd(day,-280,Convert(date,'"+ sdate + "')),GETDATE())) as terk1, dbo.ufnWeekPregnancy((DATEDIFF(day, dateadd(day, -280, Convert(date, '"+ sdate + "')), GETDATE()))) as terk2;";
                command = new SqlCommand(sql, sqlconn);
                dataReader = command.ExecuteReader();
           
                while (dataReader.Read())
                {

                    _mom_date.mom_count_date = dataReader["terk1"].ToString();
                    _mom_date.mom_week = dataReader["terk2"].ToString();
                    //_customer.no = no++;
                    //_customer.date = dataReader["tbGigya_registerDate"].ToString();
                    //_customer.name = dataReader["profile_firstName"].ToString();
                    //_customer.lname = dataReader["profile_lastName"].ToString();
                    //_customer.phone = dataReader["profile_mobile"].ToString();
                    //_customer.email = dataReader["profile_email"].ToString();
                    //_customer.replace = count_t.get_value(dataReader["tbCRM_id"].ToString()).ToString();
                    //_customer.case_no = "Active";
                    //_customer.status = "";
                    //_customer.customer_id = dataReader["tbCRM_id"].ToString();
                    //_customer.sub_district = dataReader["profile_addressLine2"].ToString();
                    //_customer.district = dataReader["profile_city"].ToString();
                    //_customer.province = dataReader["profile_region"].ToString();
                    //_customer.zipcode = dataReader["profile_zip"].ToString();
                    //_customer.Child_birthdate = dataReader["crm_childBirthDate_used"].ToString();
                    //_customer.profile_address_Line1 = dataReader["profile_address_Line1"].ToString();
                }


                sqlconn.Close();
            }

            return _mom_date;
        }
    }
}
