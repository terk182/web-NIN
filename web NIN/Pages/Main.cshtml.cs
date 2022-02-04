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
    public class MainModel : PageModel
    {
        public IActionResult OnGet(string agent)
        {
            var login_status = "";
            ViewData["terk"] = "terk";


            ViewData["user"] = HttpContext.Session.GetString("username");



            ViewData["password"] = HttpContext.Session.GetString("password");
            ViewData["agent"] = HttpContext.Session.GetString("username");
            ViewData["login"] = HttpContext.Session.GetString("login"); 
            login_status = HttpContext.Session.GetString("login");
            var agent_name = HttpContext.Session.GetString("username");
            if (string.IsNullOrEmpty(agent))
            {
                agent_name = HttpContext.Session.GetString("username");
            }
            else
            {
                agent_name = agent;
            }

            var _get_agint_id = new get_agint_id();
            var agent_id = _get_agint_id.get_value(agent_name);




            



            var customer_list_check = new List<customer>();

            var terk = new service_customer();

            var list_customer = terk.get_customer(agent_id.id.ToString());

            int no = 1;
            foreach (var value in list_customer)
            {
           
                    customer_list_check.Add(new customer
                    {
                        no = no++,
                        date = value.date,
                        name = value.name,
                        lname = value.lname,
                        phone = value.phone,
                        email = value.email,
                        replace = value.replace,

                        case_no = value.case_no,
                        detail = value.detail,
                        status = value.status,
                        customer_id = value.customer_id,
                        catagory = "0"

                    });
                
            }


            var terk2 = new service_customer2();

            var list_customer2 = terk2.get_customer(agent_id.id.ToString());

            string numm = "";
            foreach (var value in list_customer2)
            {
                if (String.IsNullOrEmpty(value.catagory)) 
                {
                    numm = "2";
                }
                else
                {
                    numm = (Int32.Parse(value.catagory) + 1).ToString();
                   
                }
                customer_list_check.Add(new customer
                    {
                        no = no++,
                        date = value.date,
                        name = value.name,
                        lname = value.lname,
                        phone = value.phone,
                        email = value.email,
                        replace = value.replace,

                        case_no = value.case_no,
                        detail = value.detail,
                        status = "pending",
                        customer_id = value.customer_id,
                        catagory = numm
                });
               
            }









            ViewData["customer"] = customer_list_check;

            if (login_status != "true")
            {
                return new RedirectToPageResult("/Index");
            }
            return Page();
        }
        [HttpGet]
        public IActionResult OnGetTakelog(string id)
        {
            var _get_log = new get_log();
            var _result = _get_log.get_value(id);
            var json1 = JsonSerializer.Serialize(_result);
            return new JsonResult(json1);
        }

        [HttpGet]
        public IActionResult OnGetUpdatelog(string command)
        {
            var sql = new update_mom_data();
            var result = sql.set_value(command);


            


            return new JsonResult(result);
        }

    }
}
