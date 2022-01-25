using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using web_NIN.Models;

namespace web_NIN.Services
{
    public class get_result
    {
        public List<result_model> get_value(int id)
        {
            var provinces_model_list = new List<result_model>();

            var txt = new Db_connect();

            using (SqlConnection sqlconn = new SqlConnection(txt.Db_connect_string()))
            {
                sqlconn.Open();
                var sql = "";
                SqlCommand command;
                SqlDataReader dataReader;

                sql = "select top 1 * from nin_result_record where customerID =" + id + " order by id desc";
                command = new SqlCommand(sql, sqlconn);
                dataReader = command.ExecuteReader();
                string[] hhh = {   "id" ,
                                    "create_date" ,
                                    "create_time"  ,
                                    "create_operator_name" ,
                                    "create_operator_id" ,
                                    "update_date" ,
                                    "update_time"  ,
                                    "update_operator_name" ,
                                    "update_operator_id" ,
                                    "remark" ,
                                    "OperatorID" ,
                                    "customerID" ,
                                    "customer_name" ,
                                    "recall" ,
                                    "born_status" ,
                                    "birthDate_original" ,
                                    "result_bday_th_original" ,
                                    "birthDate_new" ,
                                    "result_bday_th_new" ,
                                    "child_name" ,
                                    "milk_type" ,
                                    "milk_brand" ,
                                    "health_problems" ,
                                    "worry" ,
                                    "other" ,
                                    "annotation" ,
                                    "numberOfRepeat" ,
                                    "status" ,
                                    "type" ,
                                    "agent_id" ,
                                    "result_annotation" ,};
                string[] hhh_th = {   "row ที่" ,
                                    "บันทึกในวัน" ,
                                    "บันทึกในเวลา"  ,
                                    "ผู้สร้างข้อมูล" ,
                                    "create_operator_id" ,
                                    "update_date" ,
                                    "update_time"  ,
                                    "update_operator_name" ,
                                    "update_operator_id" ,
                                    "remark" ,
                                    "OperatorID" ,
                                    "customerID" ,
                                    "ชื่อคุณแม่" ,
                                    "recall" ,
                                    "สถานะการคลอด" ,
                                    "กำหนดคลอดเดิม" ,
                                    "อายุน้อง คำนวนจากกำหนดคลอดเดิม" ,
                                    "แก้ไขวันเกิด" ,
                                    "อายุน้อง คำนวนจากวันเกิดใหม่" ,
                                    "ชื่อน้อง" ,
                                    "น้องดื่ม" ,
                                    "ยี่ห้อนมที่น้องดื่ม" ,
                                    "บัญหาสุภาพของน้อง" ,
                                    "ความกังวลใจของคุณแม่" ,
                                    "บัญหาอื่นๆ" ,
                                    "คำอธิบายเพิมเติม" ,
                                    "จำนวนครั้งในการโทร" ,
                                    "สถานะ" ,
                                    "ประเภท" ,
                                    "agent_id" ,
                                    "หมายดหตุ" ,};
                string[] roww_id = {"1" ,
                                    "2" ,
                                    "3"  ,
                                    "4" ,
                                    "5" ,
                                    "6" ,
                                    "7"  ,
                                    "8" ,
                                    "9" ,
                                    "10" ,
                                    "11" ,
                                    "12" ,
                                    "13" ,
                                    "14" ,
                                    "15" ,
                                    "16" ,
                                    "17" ,
                                    "18" ,
                                    "19" ,
                                    "20" ,
                                    "21" ,
                                    "22" ,
                                    "23" ,
                                    "24" ,
                                    "25" ,
                                    "26" ,
                                    "27" ,
                                    "28" ,
                                    "29" ,
                                    "30" ,
                                    "31" ,};
                string[] hhh_tt = {   "row ที่" ,
                                    "บันทึกในวัน" ,
                                    "บันทึกในเวลา"  ,
                                    "ผู้สร้างข้อมูล" ,
                                    "create_operator_id" ,
                                    "update_date" ,
                                    "update_time"  ,
                                    "update_operator_name" ,
                                    "update_operator_id" ,
                                    "remark" ,
                                    "OperatorID" ,
                                    "customerID" ,
                                    "ชื่อคุณแม่" ,
                                    "recall" ,
                                    "สถานะการคลอด" ,
                                    "กำหนดคลอดเดิม" ,
                                    "อายุครรภ์  คำนวนจากกำหนดคลอดเดิม" ,
                                    "กำหนดคลอดใหม่" ,
                                    "อายุครรภ์ คำนวนจากกำหนดคลอดใหม่" ,
                                    "ชื่อน้อง" ,
                                    "น้องดื่ม" ,
                                    "ยี่ห้อนมที่น้องดื่ม" ,
                                    "บัญหาสุภาพของน้อง" ,
                                    "ความกังวลใจของคุณแม่" ,
                                    "บัญหาอื่นๆ" ,
                                    "คำอธิบายเพิมเติม" ,
                                    "จำนวนครั้งในการโทร" ,
                                    "สถานะ" ,
                                    "ประเภท" ,
                                    "agent_id" ,
                                    "หมายดหตุ" ,};
                while (dataReader.Read())
                {

                    for (int i = 0; i < hhh.Length; i++)
                    {
                        provinces_model_list.Add(new result_model
                        {
                            topic = hhh[i],
                            result = dataReader[hhh[i]].ToString(),
                            topic_th1 = hhh_th[i],
                            topic_th2 = hhh_tt[i],
                            row_id = roww_id[i]
                            //id = Int32.Parse(dataReader["id"].ToString()),
                            //thai_status = dataReader["thai_status"].ToString(),
                            //eng_status = dataReader["eng_status"].ToString(),
                            //id = Int32.Parse(dataReader["id"].ToString()),
                            //code = dataReader["code"].ToString(),
                            //name_th = dataReader["name_th"].ToString(),
                            //name_en = dataReader["name_en"].ToString(),
                            //geography_id = Int32.Parse(dataReader["geography_id"].ToString()),


                        }); ; 
                    }


                   
                }


                sqlconn.Close();
            }

            return provinces_model_list;
        }
    }
}
