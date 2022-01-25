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
using Newtonsoft.Json.Linq;

namespace web_NIN.Pages
{
    public class adminModel : PageModel
    {
        
        public IActionResult OnGet(string date)
        {
           
            var login_status = "";
            ViewData["sql_date"] = date;
            ViewData["user"] = HttpContext.Session.GetString("username");
            ViewData["password"] = HttpContext.Session.GetString("password");
            ViewData["agent"] = HttpContext.Session.GetString("username");
            ViewData["login"] = HttpContext.Session.GetString("login");
            login_status = HttpContext.Session.GetString("login");
            var _customer_count = new customer_count();
            var total_data = _customer_count.count_customer().row_data;
            ViewData["total_customer"] = total_data;
            var _agent_count = new agent_count();
            ViewData["total_agent"] = _agent_count.count_agent().row_data;
            var _assign_count = new assign_count();
            ViewData["total_assign"] = _assign_count.count_assign().row_data;

            var count_sub = total_data / 1000;
            var count_modul = total_data % 1000;
            var itti = new List<page_select>();
            int y = 0;
            for (int i = 0; i < count_sub; i++)
            {
                itti.Add(new page_select
                { min_index = (y * 1000).ToString(), max_index = (++y * 1000).ToString(), }

                    );
            }
            itti.Add(new page_select
            { min_index = (++y * 1000).ToString(), max_index = ((++y * 1000)+ count_modul).ToString(), }

                    );

            ViewData["page_list"] = itti;

            var _agent_data = new agent_data();

            ViewData["agent_list"] = _agent_data.get_value();

            var _get_mom_by_date = new get_mom_by_date();
            ViewData["mom_list"] = _get_mom_by_date.get_value(date);

            if (login_status != "true")
            {
                return new RedirectToPageResult("/Index");
            }
            return Page();
        }
        [HttpGet]
        public IActionResult OnGetUpdatemom(string command,string min_u,string max_u) //Assign
        {
            var _between_find = new between_find();
            var _result = _between_find.get_customer(command, min_u, max_u);
            var json1 = JsonSerializer.Serialize(_result);
            return new JsonResult(json1);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult OnPostTerk([FromBody] string command) //Assign
        {
            var ttt = command;
            return new JsonResult(command);
        }

        [HttpGet]
        public IActionResult OnGetAssign2( string count,string agent_id,string ageni_name,string date_txt) //Assign
        {
            var _g_mom_by_date = new get_mom_by_date();
            var terk_ii = _g_mom_by_date.get_value(date_txt);

            var _requestObj = new List<RequestObj>();
            int count_loop = Int32.Parse(count);
            int loop_check = 0;
            foreach (var value in terk_ii)
            {
                if(string.IsNullOrEmpty(value.agent_id))
                {
                    loop_check++;
                    _requestObj.Add(new RequestObj
                    {
                       
                        create_operator_name = ageni_name,
                        operatorID = agent_id,
                        custommerID = value.customer_id,
                        custommer_name = value.name ,
                        phone = value.phone,
                    }) ;
                }
                if (loop_check  >= count_loop)
                {
                    break;
                }

            }

            var _insert_assign = new insert_assign();
            _insert_assign.set_value(_requestObj);

            var _update_agent_id_to_custommer = new update_agent_id_to_custommer();
            _update_agent_id_to_custommer.set_value(_requestObj, agent_id);


            return new JsonResult(date_txt);
        }


        [HttpGet]
        public IActionResult OnGetAssign(string command) //Assign
        {
            using JsonDocument doc = JsonDocument.Parse(command);
            var _reRequestObj = new List<RequestObj>();
            JsonElement root = doc.RootElement;
            var cc = root.GetArrayLength();
         
            for (int i = 0; i < cc; i++)
            {
                _reRequestObj.Add(new RequestObj
                {
                    create_operator_name = root[i].GetProperty("create_operator_name").ToString(),
                    operatorID = root[i].GetProperty("operatorID").ToString(),
                    custommerID = root[i].GetProperty("custommerID").ToString(),
                    custommer_name = root[i].GetProperty("custommer_name").ToString(),
                    phone = root[i].GetProperty("phone").ToString(),
                });
            }
            var _insert_assign = new insert_assign();
            _insert_assign.set_value(_reRequestObj);

            var _update_agent_id_to_custommer = new update_agent_id_to_custommer();
            _update_agent_id_to_custommer.set_value(_reRequestObj,"");


                return new JsonResult("terk");
        }
        [HttpGet]
        public IActionResult OnGetTakelog(string id)
        {
            var _agent_service_by_id = new agent_service_by_id();
            var _result = _agent_service_by_id.get_value(id);
            var json1 = JsonSerializer.Serialize(_result);
            return new JsonResult(json1);
        }
    }
}

