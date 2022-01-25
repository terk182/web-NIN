using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using web_NIN.Models;

namespace web_NIN.Services
{
    public class calendar_service
    {
        public List<calendar_model> get_value(string date_t)
        {
            var calendar_model_list = new List<calendar_model>();

            var txt = new Db_connect();

            using (SqlConnection sqlconn = new SqlConnection(txt.Db_connect_string()))
            {
                sqlconn.Open();
                var sql = "";
                SqlCommand command;
                SqlDataReader dataReader;

                sql = "SELECT CONVERT(VARCHAR(20),t1.crm_childBirthDate_used,105) as tbGigya_registerDate,t1.profile_firstName,t1.profile_lastName,t1.profile_mobile FROM tbNIN_CRM_Outbound t1 WHERE t1.crm_childBirthDate_used LIKE '%" + date_t + "%' and crm_outboundGroup ='Pregnancy' and data_subscriptions_THnestlegrp_Oonestle_email =1 ";
                command = new SqlCommand(sql, sqlconn);
                dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {

                    calendar_model_list.Add(new calendar_model
                    {
                         profile_firstName = dataReader["profile_firstName"].ToString(),
                         profile_lastName = dataReader["profile_lastName"].ToString(),
                         profile_mobile = dataReader["profile_mobile"].ToString(),
                         tbGigya_registerDate = dataReader["tbGigya_registerDate"].ToString(),

                    });
                }


                sqlconn.Close();
            }

            return calendar_model_list;
        }
    }
}
