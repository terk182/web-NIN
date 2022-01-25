using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace web_NIN.Services
{
    public class updata_customer_status
    {
        public bool set_value(string id)
        {
            var txt = new Db_connect();

            using (SqlConnection sqlconn = new SqlConnection(txt.Db_connect_string()))
            {

                var sql = "";
                SqlCommand command;


                //sql = "insert into dbo.nin_assign (create_date, create_time, create_operator_name, operatorID,custommerID,customer_name,phone,status ) values ";
                sql = "update dbo.tbNIN_CRM_Outbound SET status = 'Complete' where tbCRM_id = '" + id+"'";
               

                command = new SqlCommand(sql, sqlconn);
                sqlconn.Open();
                command.ExecuteNonQuery();




                return true;
            }

        }
    }
}
