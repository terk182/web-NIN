using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using web_NIN.Models;

namespace web_NIN.Services
{
    public class get_assign
    {
        public List<assign_model> get_name(string name)
        {
            var Status_call_list = new List<assign_model>();
            var _Status_call = new assign_model();
            var txt = new Db_connect();

            using (SqlConnection sqlconn = new SqlConnection(txt.Db_connect_string()))
            {
                sqlconn.Open();
                var sql = "";
                SqlCommand command;
                SqlDataReader dataReader;

                sql = "SELECT t1.create_date,t2.profile_firstName,t2.profile_lastName,t2.profile_mobile,t2.profile_email,t1.operatorID,t2.status as status_mom,t2.update_status,t1.numberOfRepeat,t1.status AS status_m_agent,t1.statusOfCase,t2.tbCRM_id FROM nin_assign t1 LEFT JOIN tbNIN_CRM_Outbound t2 ON t2.tbCRM_id = t1.custommerID WHERE t1.operatorID = '" + name + "'";
                command = new SqlCommand(sql, sqlconn);
                dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {

                    Status_call_list.Add(new assign_model
                    {
                        date = dataReader["create_date"].ToString(),
                        mom_name = dataReader["profile_firstName"].ToString(),
                        mom_lname = dataReader["profile_lastName"].ToString(),
                        phone = dataReader["profile_mobile"].ToString(),
                        email = dataReader["profile_email"].ToString(),
                        agent_id = dataReader["operatorID"].ToString(),
                        status = dataReader["status_m_agent"].ToString(),
                        statusOfCase = dataReader["statusOfCase"].ToString(),
                        custommerID =  dataReader["tbCRM_id"].ToString(),
                        numberOfRepeat = dataReader["numberOfRepeat"].ToString(),
                        //id = Int32.Parse(dataReader["id"].ToString()),
                        //thai_status = dataReader["thai_status"].ToString(),
                        //eng_status = dataReader["eng_status"].ToString(),

                    }) ;
                }


                sqlconn.Close();
            }

            return Status_call_list;
        }
        public List<assign_model> get_all()
        {
            var Status_call_list = new List<assign_model>();
            var _Status_call = new assign_model();
            var txt = new Db_connect();

            using (SqlConnection sqlconn = new SqlConnection(txt.Db_connect_string()))
            {
                sqlconn.Open();
                var sql = "";
                SqlCommand command;
                SqlDataReader dataReader;

                sql = "SELECT t1.create_date,t2.profile_firstName,t2.profile_lastName,t2.profile_mobile,t2.profile_email,t1.operatorID,t2.status as status_mom,t2.update_status,t1.numberOfRepeat,t1.status AS status_m_agent,t1.statusOfCase,t2.tbCRM_id FROM nin_assign t1 LEFT JOIN tbNIN_CRM_Outbound t2 ON t2.tbCRM_id = t1.custommerID";
                command = new SqlCommand(sql, sqlconn);
                dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {

                    Status_call_list.Add(new assign_model
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
                        //id = Int32.Parse(dataReader["id"].ToString()),
                        //thai_status = dataReader["thai_status"].ToString(),
                        //eng_status = dataReader["eng_status"].ToString(),

                    });
                }


                sqlconn.Close();
            }

            return Status_call_list;
        }


        public List<assign_model> get_not_complete(string call)
        {
            var Status_call_list = new List<assign_model>();
            var _Status_call = new assign_model();
            var txt = new Db_connect();

            using (SqlConnection sqlconn = new SqlConnection(txt.Db_connect_string()))
            {
                sqlconn.Open();
                var sql = "";
                SqlCommand command;
                SqlDataReader dataReader;

                sql = "SELECT t1.create_date, t2.profile_firstName, t2.profile_lastName,t2.profile_mobile, t2.profile_email, t1.operatorID, t2.status AS status_mom, t2.update_status, t1.numberOfRepeat, t1.status AS status_m_agent,t1.statusOfCase, t2.tbCRM_id FROM nin_assign AS t1 LEFT JOIN tbNIN_CRM_Outbound t2 ON t2.tbCRM_id = t1.custommerID WHERE(t1.status NOT IN('Complete', 'Wrong Number', 'Foreign customers', 'On Behalf of Owner')) AND(t1.status <> 'Miscarry') AND (numberOfRepeat = '"+call+"') AND t1.statusOfCase = 'Unreachable' ORDER BY t2.tbCRM_id";
                command = new SqlCommand(sql, sqlconn);
                dataReader = command.ExecuteReader();
                string st_check = "";
       
                while (dataReader.Read())
                {

                    st_check = dataReader["status_m_agent"].ToString();

                    if (st_check == "On Behalf of Owner"  || st_check == "Wrong Number" || st_check == "Foreign customers")
                    {
                       
                    }
                    else
                    {
                        Status_call_list.Add(new assign_model
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
                           // st_id = dataReader["s_id"].ToString(),
                            //id = Int32.Parse(dataReader["id"].ToString()),
                            //thai_status = dataReader["thai_status"].ToString(),
                            //eng_status = dataReader["eng_status"].ToString(),

                        });
                    }

                  
                }


                sqlconn.Close();
            }

            return Status_call_list;
        }

        public List<assign_model> get_not_complete_baby(string call)
        {
            var Status_call_list = new List<assign_model>();
            var _Status_call = new assign_model();
            var txt = new Db_connect();

            using (SqlConnection sqlconn = new SqlConnection(txt.Db_connect_string()))
            {
                sqlconn.Open();
                var sql = "";
                SqlCommand command;
                SqlDataReader dataReader;

                sql = "SELECT t1.create_date, t2.profile_firstName, t2.profile_lastName,t2.profile_mobile, t2.profile_email, t1.operatorID, t2.status AS status_mom, t2.update_status, t1.numberOfRepeat, t1.status AS status_m_agent,t1.statusOfCase, t2.tbCRM_id FROM nin_assign AS t1 LEFT JOIN tbNIN_CRM_Outbound t2 ON t2.tbCRM_id = t1.custommerID WHERE(t1.status NOT IN('Complete', 'Wrong Number', 'Foreign customers', 'On Behalf of Owner')) AND(t1.status <> 'Miscarry') AND (numberOfRepeat = '" + call + "') AND t1.statusOfCase = 'Unreachable' AND t1.type = 'baby' ORDER BY t2.tbCRM_id";
                command = new SqlCommand(sql, sqlconn);
                dataReader = command.ExecuteReader();
                string st_check = "";

                while (dataReader.Read())
                {

                    st_check = dataReader["status_m_agent"].ToString();

                    if (st_check == "On Behalf of Owner" || st_check == "Wrong Number" || st_check == "Foreign customers")
                    {

                    }
                    else
                    {
                        Status_call_list.Add(new assign_model
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
                            // st_id = dataReader["s_id"].ToString(),
                            //id = Int32.Parse(dataReader["id"].ToString()),
                            //thai_status = dataReader["thai_status"].ToString(),
                            //eng_status = dataReader["eng_status"].ToString(),

                        });
                    }


                }


                sqlconn.Close();
            }

            return Status_call_list;
        }
    }
}
