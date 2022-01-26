using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using web_NIN.Models;
using web_NIN.Services;

namespace web_NIN.Pages
{
    public class OutboundModel : PageModel
    {
        public string customer_id { get; set; } = "";
        public string customer_name { get; set; } = "";
        public string customer_phone { get; set; } = "";
        public string customer_idd = "";
        public IActionResult OnGet(int id,string tel,string replace,string st)
        {
            var login_status = "";
            ViewData["st"] = st;
            ViewData["replace"] = replace;
            ViewData["mom_id"] = id.ToString();
            ViewData["user"] = HttpContext.Session.GetString("username");
            ViewData["password"] = HttpContext.Session.GetString("password");
            ViewData["agent"] = HttpContext.Session.GetString("username");
            ViewData["login"] = HttpContext.Session.GetString("login");
            login_status = HttpContext.Session.GetString("login");

            this.customer_idd = id.ToString();
            this.customer_id = id.ToString();
            this.customer_phone = tel;
            var command = new Status_call();
          
            ViewData["status_call"] = command.get_status_call();
            ViewData["tel"] = tel;
            var command1 = new customer_data();

            var customer_data = command1.get_customer_data(id);

            ViewData["customer_name"] = customer_data.name +" "+ customer_data.lname;
            ViewData["cm_email"] = customer_data.email;
            ViewData["cm_phone"] = customer_data.phone;
            ViewData["cm_province"] = customer_data.province;
            ViewData["cm_district"] = customer_data.district;
            ViewData["cm_sub_district"] = customer_data.sub_district;
            ViewData["cm_zipcode"] = customer_data.zipcode;
            
            ViewData["profile_address_Line1"] = customer_data.profile_address_Line1;
            if (string.IsNullOrEmpty(customer_data.Child_birthdate))
            {
               
                ViewData["Child_age"] = "ไม่มีข้อมูล";
                ViewData["bond_age"] = "ไม่มีข้อมูล";
            }
            else
            {
                var ddd = "";
                 ddd = customer_data.Child_birthdate;
                string[] date_sub = ddd.Split('/');
                string[] date_sub1 = date_sub[2].Split(' ');

                int result = Int32.Parse(date_sub1[0]);
                int result_ = result - 543;
               // int result_ = result;
                var date_convent = date_sub[0] + "/" + date_sub[1] + "/" + result_.ToString();
                var mmmm = Int32.Parse(date_sub[0]);
                var mmmm2 = Int32.Parse(date_sub[1]);
                var m_txt = "";
                var m_txt2 = "";
                if (mmmm <10)
                {
                    m_txt = "0" + mmmm.ToString();
                }
                else
                {
                    m_txt = mmmm.ToString();
                }
                if (mmmm2 < 10)
                {
                    m_txt2 = "0" + mmmm2.ToString();
                }
                else
                {
                    m_txt2 = mmmm2.ToString();
                }
                var date_convent_1 =  result_.ToString() + m_txt2 + m_txt;
                //var DATE = Convert.ToDateTime(date_convent);
                
                
                
                 if (result >2500)
                {
                    ViewData["Child_birthdate"] = date_convent;
                }
              else
                {
                    ViewData["Child_birthdate"] = customer_data.Child_birthdate;
                }
                var DATE = Convert.ToDateTime(customer_data.Child_birthdate);
                var _age_cal = new age_cal(DATE);
                var result_date = _age_cal.Count(DATE);
                var ggg = _age_cal.count_bday(DATE);
                var ggg1 = ggg / 7;

                var _get_mom_date = new get_mom_date();
                var mm = _get_mom_date.get_mom_date_t(date_convent_1);
                ViewData["bond_age_tt"] = ggg;
                if (ggg1 > 40)
                {
                    ViewData["bond_age_t"] = "คุณแม่ได้เลยกำหนดคลอดแล้ว";
                }
               else
                 {
                    ViewData["bond_age_t"] = "";
                }


                if (result_date.Years <1 && result_date.Months <1 && result_date.Days <1)
                {
                    ViewData["Child_age"] = "";
                    ViewData["bond_age"] = "อายุครรภ์ " + mm.mom_week;
                }
                else
                {
                    ViewData["Child_age"] = "น้องอายุ " + result_date.Years + " ปี " + result_date.Months + " เดือน " + result_date.Days + " วัน";
                    ViewData["bond_age"] = "อายุครรภ์ " + mm.mom_week;
                    
                }
  
            }
            

            var command2 = new maternity_status();
     
            ViewData["maternity"] = command2.get_maternity_status();

            var _type_of_milk = new type_of_milk();
            ViewData["type_of_milk"] = _type_of_milk.get_type_milk();

            var _brand_of_milk = new brand_of_milk();
            ViewData["brand_of_milk"] = _brand_of_milk.get_value();

            var _type_of_worried = new type_of_worried();
            ViewData["type_of_worried"] = _type_of_worried.get_value();

            var _type_problem = new type_problem();
            ViewData["type_problem"] = _type_problem.get_value();

            var _cancel_data = new cancel_data();
            ViewData["cancel_data"] = _cancel_data.get_value();

            var _provinces = new provinces();
            ViewData["provinces"] = _provinces.get_value();

            if (login_status != "true")
            {
                return new RedirectToPageResult("/Index");
            }
            return Page();

        }
        public IActionResult OnGetDemo1(int id)
        {
            return new JsonResult(id);
        }
        [HttpGet]
        public IActionResult OnGetProducts(string id)
        {
            var _amphures = new amphures();
            var amphures_data = _amphures.get_value(id);

            var json = JsonSerializer.Serialize(amphures_data);
            return new JsonResult(json); 
        }

        [HttpGet]
        public IActionResult OnGetDistricts(string id)
        {
            var _districts = new districts();
            var _districts_data = _districts.get_value(id);

            var json1 = JsonSerializer.Serialize(_districts_data);
            return new JsonResult(json1);
        }


        [HttpGet]
        public IActionResult OnGetInsertlog(string status,string action, string customer_id,string next_t,string replace)
        {
            var ppp = HttpContext.Session.GetString("password");
            var agent = HttpContext.Session.GetString("username");
            
            var _logmodel = new Logmodel();
            _logmodel.status = status;
            _logmodel.acton = action;
            _logmodel.create_operator_name = agent;
            _logmodel.operatorID = agent;
            _logmodel.custommerID = customer_id;
            _logmodel.datail = next_t;
            _logmodel.numberOfRepeat = Int32.Parse(replace);
            var _insert_log = new insert_log();
            _insert_log.set_value(_logmodel);


            var update_command = "UPDATE nin_assign SET status = '"+ status + "', statusOfCase = 'Unreachable', numberOfRepeat = '" + replace + "' WHERE custommerID = '" + customer_id + "'";

            var _update_to_assign = new update_to_assign();
            _update_to_assign.set_value(update_command);

            return new JsonResult(status);
        }
        [HttpGet]
        public IActionResult OnGetUpdatemom(string command,string old_data, string mom_id,string agent,string command2)
        {
            var result = true;
            var sql = new update_mom_data();
            if (string.IsNullOrEmpty(command2))
            {
                 result = sql.set_value(command);
                var _insert_backup = new insert_backup();
                var backup_data = new buckup_model();
                backup_data.data_value = old_data;
                backup_data.row_id = mom_id;
                backup_data.create_operator_name = agent;
                _insert_backup.set_value(backup_data);
            }
            else
            {
                 result = sql.set_value(command);
                var result1 = sql.set_value(command2);
            }
                
            

           


            return new JsonResult(result);
        }

        [HttpGet]
        public IActionResult OnGetUpdate(string table, string header, string value,string customer, string replace,string status,string upd,string std)
        {
            var date_ = DateTime.Now.ToString("yyyy-MM-dd");
            var time_ = DateTime.Now.ToString("HH:mm:ss");
            //var h = "(" + header + ",create_date,create_time)";
            //var v = "(" + value + ",'" + date_ + "','" + time_ + "')";

            var std1 = std;
            var h = "(" + header + ")";
            var v = "(" + value + ")";
            var command = "INSERT INTO " + table + h + " VALUES "+ v;
            var uupdate = "UPDATE tbNIN_CRM_Outbound SET " + upd + "where tbCRM_id = '" + customer + "'";
            var update_command = "UPDATE nin_assign SET status = '" + status + "', statusOfCase = 'Reachable', numberOfRepeat = '" + replace + "' WHERE custommerID = '" + customer + "'";
            var sql = new update_mom_data();
            var result = sql.set_value(command);



            

            var result1 = sql.set_value(uupdate);



           

            var _update_to_assign = new update_to_assign();
            _update_to_assign.set_value(update_command);
            
            if(std == "true")
            {
                var update_command2 = "UPDATE nin_assign_second SET status = '" + status + "', statusOfCase = 'Reachable', numberOfRepeat = '" + replace + "' WHERE custommerID = '" + customer + "'";
                _update_to_assign.set_value(update_command2);
            }


            var user = HttpContext.Session.GetString("username");
            var _insert_log = new insert_log();
            var add_log = new Logmodel();
            add_log.status = "Complete";
            add_log.acton = "call";
            add_log.create_operator_name = user;
            add_log.operatorID = user;
            add_log.custommerID = customer;
            add_log.datail = "NA";
            add_log.numberOfRepeat = Int32.Parse(replace);
            _insert_log.set_value(add_log);


            var _updata_customer_status = new updata_customer_status();
            _updata_customer_status.set_value(customer);
            return new JsonResult(result);
        }

        [HttpGet]
        public IActionResult OnGetInsertDATA(string table,string header,string value)
        {
            
            return new JsonResult("test");
        }

        [HttpGet]
        public IActionResult OnGetMOMdate(string date)
        {
            var _get_mom_date = new get_mom_date();
            var mm = _get_mom_date.get_mom_date_t(date);
            return new JsonResult(mm.mom_week);
        }

    }
}
