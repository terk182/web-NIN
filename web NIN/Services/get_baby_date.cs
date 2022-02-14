using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using web_NIN.Models;

namespace web_NIN.Services
{
    public class get_baby_date
    {
        public List<baby_model> get_baby()
        {
            var Status_call_list = new List<baby_model>();
            var _Status_call = new baby_model();
            var txt = new Db_connect();

            using (SqlConnection sqlconn = new SqlConnection(txt.Db_connect_string()))
            {
                sqlconn.Open();
                var sql = "";
                SqlCommand command;
                SqlDataReader dataReader;

                sql = "SELECT t1.tbGigya_registerDate,t1.profile_firstName,t1.profile_lastName,t1.profile_mobile,t1.profile_email,t1.crm_childBirthDate_used,t1.tbCRM_id, DATEDIFF(day, t1.crm_childBirthDate_used, GETDATE()) AS DAY FROM tbNIN_CRM_Outbound t1 WHERE (t1.agent_id IS NULL) AND t1.crm_childBirthDate_used LIKE '%2022%'";
                command = new SqlCommand(sql, sqlconn);
                dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {

                    Status_call_list.Add(new baby_model
                    {
                        profile_firstName = dataReader["profile_firstName"].ToString(),
                        profile_lastName = dataReader["profile_lastName"].ToString(),
                        tbGigya_registerDate = dataReader["tbGigya_registerDate"].ToString(),
                        profile_mobile = dataReader["profile_mobile"].ToString(),
                        profile_email = dataReader["profile_email"].ToString(),
                        crm_childBirthDate_used = dataReader["crm_childBirthDate_used"].ToString(),
                        tbCRM_id = dataReader["tbCRM_id"].ToString(),
                        day = dataReader["DAY"].ToString(),
                       
                        //id = Int32.Parse(dataReader["id"].ToString()),
                        //thai_status = dataReader["thai_status"].ToString(),
                        //eng_status = dataReader["eng_status"].ToString(),

                    });
                }


                sqlconn.Close();
            }

            return Status_call_list;
        }
    }
}
