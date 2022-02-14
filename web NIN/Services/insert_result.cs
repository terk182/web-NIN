using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using web_NIN.Models;

namespace web_NIN.Services
{
    public class insert_result
    {
        public bool set_value(Person mom_model)
        {
            var txt = new Db_connect();

            using (SqlConnection sqlconn = new SqlConnection(txt.Db_connect_string()))
            {

                var sql = "";
                SqlCommand command;


                sql = @"insert into dbo.nin_result_record ( 
                                                    create_operator_name, 
                                                    remark,
                                                    OperatorID,
                                                    customerID,
                                                    customer_name,
                                                    born_status,
                                                    birthDate_original,
                                                    result_bday_th_original,
                                                    birthDate_new,
                                                    result_bday_th_new,
                                                    child_name,
                                                    milk_type,
                                                    milk_brand,
                                                    health_problems,
                                                    worry,
                                                    other,
                                                    annotation,
                                                    numberOfRepeat,
                                                    status,
                                                    type,
                                                    agent_id,
                                                    result_annotation,
                                                    gender,
                                                    twin_status,
                                                    twin_number,
                                                    result_annotation_1,
                                                    result_annotation_2,
                                                    result_annotation_3,
                                                    child_name_1,
                                                    birthDate_1,
                                                    result_bday_th_1,
                                                    child_gender_1,
                                                    child_name_2,
                                                    birthDate_2,
                                                    result_bday_th_2,
                                                    child_gender_2,
                                                    child_name_3,
                                                    birthDate_3,
                                                    result_bday_th_3,
                                                    child_gender_3,
                                                    child_name_4,
                                                    birthDate_4,
                                                    result_bday_th_4,
                                                    child_gender_4,
                                                    birthDate_original_date,
                                                    birthDate_new_date      
                                                    )
                                                    values ( 
                                                    @create_operator_name,
                                                    @remark,
                                                    @OperatorID,
                                                    @customerID,
                                                    @customer_name,
                                                    @born_status,
                                                    @birthDate_original,
                                                    @result_bday_th_original,
                                                    @birthDate_new,
                                                    @result_bday_th_new,
                                                    @child_name,
                                                     @milk_type,
                                                     @milk_brand,
                                                    @health_problems,
                                                    @worry,
                                                    @other,
                                                    @annotation,
                                                    @numberOfRepeat,
                                                    @status,
                                                    @type,
                                                    @agent_id,
                                                    @result_annotation,
                                                    @gender,
                                                    @twin_status,
                                                    @twin_number,
                                                    @result_annotation_1,
                                                    @result_annotation_2,
                                                    @result_annotation_3,
                                                    @child_name_1,
                                                    @birthDate_1,
                                                    @result_bday_th_1,
                                                    @child_gender_1,
                                                    @child_name_2,
                                                    @birthDate_2,
                                                    @result_bday_th_2,
                                                    @child_gender_2,
                                                    @child_name_3,
                                                    @birthDate_3,
                                                    @result_bday_th_3,
                                                    @child_gender_3,
                                                    @child_name_4,
                                                    @birthDate_4,
                                                    @result_bday_th_4,
                                                    @child_gender_4,
                                                    @birthDate_original_date,
                                                    @birthDate_new_date  
                                                    )";
                command = new SqlCommand(sql, sqlconn);

                command.Parameters.AddWithValue("@create_operator_name", mom_model.create_operator_name);
                command.Parameters.AddWithValue("@remark", mom_model.remark);
                command.Parameters.AddWithValue("@OperatorID", mom_model.create_operator_name);
                command.Parameters.AddWithValue("@customerID", mom_model.customerID);
                command.Parameters.AddWithValue("@customer_name", mom_model.customer_name);
                command.Parameters.AddWithValue("@born_status", mom_model.born_status);
                command.Parameters.AddWithValue("@birthDate_original", mom_model.birthDate_original);
                command.Parameters.AddWithValue("@result_bday_th_original", mom_model.result_bday_th_original);
                command.Parameters.AddWithValue("@birthDate_new", mom_model.birthDate_new);
                command.Parameters.AddWithValue("@result_bday_th_new", mom_model.result_bday_th_new);
                command.Parameters.AddWithValue("@child_name", mom_model.child_name);
                command.Parameters.AddWithValue("@milk_type", mom_model.milk_type);
                command.Parameters.AddWithValue("@milk_brand", mom_model.milk_brand); 
                command.Parameters.AddWithValue("@health_problems", mom_model.health_problems); 
                command.Parameters.AddWithValue("@worry", mom_model.worry);
                command.Parameters.AddWithValue("@other", mom_model.other);
                command.Parameters.AddWithValue("@annotation", mom_model.result_annotation);
                command.Parameters.AddWithValue("@numberOfRepeat", mom_model.replace);
                command.Parameters.AddWithValue("@status", mom_model.status);
                command.Parameters.AddWithValue("@type", "");
                command.Parameters.AddWithValue("@agent_id", "");
                command.Parameters.AddWithValue("@result_annotation", mom_model.result_annotation);
                command.Parameters.AddWithValue("@gender", mom_model.gender);
                command.Parameters.AddWithValue("@twin_status", mom_model.twin_status);
                command.Parameters.AddWithValue("@twin_number", mom_model.twin_number);
                command.Parameters.AddWithValue("@result_annotation_1", mom_model.result_annotation_1);
                command.Parameters.AddWithValue("@result_annotation_2", mom_model.result_annotation_2);
                command.Parameters.AddWithValue("@result_annotation_3", mom_model.result_annotation_3);
                command.Parameters.AddWithValue("@child_name_1", mom_model.child_name_1);
                command.Parameters.AddWithValue("@birthDate_1", mom_model.birthDate_1);
                command.Parameters.AddWithValue("@result_bday_th_1", mom_model.result_bday_th_1);
                command.Parameters.AddWithValue("@child_gender_1", mom_model.child_gender_1);
                command.Parameters.AddWithValue("@child_name_2", mom_model.child_name_2);
                command.Parameters.AddWithValue("@birthDate_2", mom_model.birthDate_2);
                command.Parameters.AddWithValue("@result_bday_th_2", mom_model.result_bday_th_2);
                command.Parameters.AddWithValue("@child_gender_2", mom_model.child_gender_2);
                command.Parameters.AddWithValue("@child_name_3", mom_model.child_name_3);
                command.Parameters.AddWithValue("@birthDate_3", mom_model.birthDate_3);
                command.Parameters.AddWithValue("@result_bday_th_3", mom_model.result_bday_th_3);
                command.Parameters.AddWithValue("@child_gender_3", mom_model.child_gender_3);
                command.Parameters.AddWithValue("@child_name_4", mom_model.child_name_4);
                command.Parameters.AddWithValue("@birthDate_4", mom_model.birthDate_4);
                command.Parameters.AddWithValue("@result_bday_th_4", mom_model.birthDate_4);
                command.Parameters.AddWithValue("@child_gender_4", mom_model.child_gender_4);
                command.Parameters.AddWithValue("@birthDate_original_date", mom_model.b_original);
                command.Parameters.AddWithValue("@birthDate_new_date", mom_model.b_new);

                sqlconn.Open();
                command.ExecuteNonQuery();

                return true;
            }

        }
    }
}
