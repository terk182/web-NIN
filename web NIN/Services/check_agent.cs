using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using web_NIN.Models;

namespace web_NIN.Services
{
    public class check_agent
    {
        public bool agent_in_database(string name)
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

                sql = "select  * from CelelacBKK where No = " + name;
                command = new SqlCommand(sql, sqlconn);
                dataReader = command.ExecuteReader();
                int no = 1;
                var count_t = new check_numberOfRepeat();
                while (dataReader.Read())
                {


                    _customer.no = no++;
                    _customer.date = dataReader["DateRegister"].ToString();
                    _customer.name = dataReader["FullName"].ToString();
                    _customer.phone = dataReader["Mobile"].ToString();
                    _customer.email = "xxxxx@xmail.com-->ID : " + dataReader["No"].ToString();
                    _customer.replace = count_t.get_value(dataReader["No"].ToString()).ToString();
                    _customer.case_no = "Active";
                    _customer.status = "";
                    _customer.customer_id = dataReader["No"].ToString();
                    _customer.sub_district = dataReader["sub_district"].ToString();
                    _customer.district = dataReader["district"].ToString();
                    _customer.province = dataReader["province"].ToString();
                    _customer.zipcode = dataReader["zipcode"].ToString();

                }


                sqlconn.Close();
            }

            return true;
        }
    }
}
