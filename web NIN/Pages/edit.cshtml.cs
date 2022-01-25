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
    public class editModel : PageModel
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
                var _customer_count = new assign_count();
                var total_data = _customer_count.count_assign().row_data;
                //ViewData["total_customer"] = total_data;
                //var _agent_count = new agent_count();
                //ViewData["total_agent"] = _agent_count.count_agent().row_data;
                //var _assign_count = new assign_count();
                //ViewData["total_assign"] = _assign_count.count_assign().row_data;

                var count_sub = total_data / 10;
                var count_modul = total_data % 10;
                var itti = new List<page_select>();
                int y = 0;
                for (int i = 0; i < count_sub; i++)
                {
                    itti.Add(new page_select
                    { min_index = (y * 10).ToString(), max_index = (++y * 10).ToString(), }

                        );
                }
                itti.Add(new page_select
                { min_index = (++y * 10).ToString(), max_index = ((++y * 10) + count_modul).ToString(), }

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
        public IActionResult OnGetCheck_assign(string command, string min_u, string max_u) //Assign
        {
            var _get_assign = new get_assign();
            var _between_assign_id = new between_assign_id();
            var _result = new List<assign_model>();
            if (command == "all")
            {
                _result = _get_assign.get_all();
            }
            else if(command == "id")
            {
                _result = _between_assign_id.get_value(min_u, max_u);
            }
            else if(command == "date")
            {
                _result = _between_assign_id.get_value(min_u, max_u);
            }
            else
            {
                _result = _get_assign.get_name(min_u);
            }

            //get_assign
            
          
            var json1 = JsonSerializer.Serialize(_result);
            return new JsonResult(json1);
        }

        [HttpGet]
        public IActionResult OnGetUpdateAssign(string mom_id, string agen_id) //Assign
        {
            var usser = HttpContext.Session.GetString("username");
            var _update_custmor_new_agent = new update_custmor_new_agent();
            _update_custmor_new_agent.set_value(agen_id, mom_id);
            var _update_to_new_assign = new update_to_new_assign();
            _update_to_new_assign.set_value(agen_id, mom_id, usser);
            return new JsonResult(mom_id);
        }

        [HttpGet]
        public IActionResult OnGetUpdateAll(string agen_id, string list) //Assign
        {
            string[] mom_id_list = list.Split(',');
            var buck = new List<RequestObj>();
            var usser = HttpContext.Session.GetString("username");
            for (int i = 0; i < mom_id_list.Length; i++)
            {
                buck.Add(new RequestObj
                {
                    custommerID = mom_id_list[i],
                    operatorID = agen_id,
                    create_operator_name = usser

                }); 
            }
            var _update_agent_id_to_custommer = new update_agent_id_to_custommer();
            _update_agent_id_to_custommer.set_value(buck, agen_id);

            var _update_to_new_assign_all = new update_to_new_assign_all();
            _update_to_new_assign_all.set_value(buck);
                    //var usser = HttpContext.Session.GetString("username");
                    //var _update_custmor_new_agent = new update_custmor_new_agent();
                    //_update_custmor_new_agent.set_value(agen_id, mom_id);
                    //var _update_to_new_assign = new update_to_new_assign();
                    //_update_to_new_assign.set_value(agen_id, mom_id, usser);
            return new JsonResult(agen_id);
        }


    }
}
