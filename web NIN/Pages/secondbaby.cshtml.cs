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
    public class secondbabyModel : PageModel
    {
        public IActionResult OnGet()
        {
            var login_status = "";

            ViewData["user"] = HttpContext.Session.GetString("username");
            ViewData["password"] = HttpContext.Session.GetString("password");
            ViewData["agent"] = HttpContext.Session.GetString("username");
            ViewData["login"] = HttpContext.Session.GetString("login");
            login_status = HttpContext.Session.GetString("login");


            var _agent_data = new agent_data();

            ViewData["agent_list"] = _agent_data.get_value();


            if (login_status != "true")
            {
                return new RedirectToPageResult("/Index");
            }
            return Page();
        }
        [HttpGet]
        public IActionResult OnGetSecondData(string call)
        {
            var _aget_assign = new get_assign();
            var _result = _aget_assign.get_not_complete_baby(call);
            var json1 = JsonSerializer.Serialize(_result);
            return new JsonResult(json1);
        }


        [HttpGet]
        public IActionResult OnGetAssignB(string agen_id, string list, string num) //Assign
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
                    create_operator_name = usser,
                    replece = num

                });
            }


            var _update_to_new_assign_all = new insert_assign_4();
            _update_to_new_assign_all.set_value(buck);

            var _update_to_assign_Unreachable = new update_to_assign_Unreachable();
            _update_to_assign_Unreachable.set_value(buck);

            return new JsonResult(agen_id);
        }
        public IActionResult OnPostAbc([FromBody] assig_baby_model person)
        {
            
            string[] mom_id_list = person.list.Split(',');
            var buck = new List<RequestObj>();
            var usser = HttpContext.Session.GetString("username");
            for (int i = 0; i < mom_id_list.Length; i++)
            {
                buck.Add(new RequestObj
                {
                    custommerID = mom_id_list[i],
                    operatorID = person.agen_id,
                    create_operator_name = usser,
                    replece = person.num

                });
            }


            var _update_to_new_assign_all = new insert_assign_4();
            _update_to_new_assign_all.set_value(buck);

            var _update_to_assign_Unreachable = new update_to_assign_Unreachable();
            _update_to_assign_Unreachable.set_value(buck);
            return new JsonResult("my result");
        }
    }
}
