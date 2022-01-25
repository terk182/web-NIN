using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using web_NIN.Models;

namespace web_NIN.Services
{
    public class get_log
    {
        public List<view_log> get_value(string agen_id)
        {
            var customer_list = new List<view_log>();
            
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

                sql = "select  * from nin_survey_log where custommerID = '" + agen_id + "'";
                command = new SqlCommand(sql, sqlconn);
                dataReader = command.ExecuteReader();
                int no = 1;
               
                while (dataReader.Read())
                {

                    customer_list.Add(new view_log
                    {
                        id = (no++).ToString(),
                        create_date = dataReader["create_date"].ToString(),
                        create_time = dataReader["create_time"].ToString(),
                        acton = dataReader["acton"].ToString(),
                        status = dataReader["status"].ToString(),
                        remark = dataReader["remark"].ToString(),
                        datail = dataReader["datail"].ToString(),
                        mom_id = dataReader["id"].ToString(),

                    });
                }


                sqlconn.Close();
            }

            return customer_list;
        }
    }
}
