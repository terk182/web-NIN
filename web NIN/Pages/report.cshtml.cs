using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using web_NIN.Services;

namespace web_NIN.Pages
{
    public class reportModel : PageModel
    {
        public IActionResult OnGet(int id)
        {
            var login_status = "";

            ViewData["mom_id"] = id.ToString();
            ViewData["user"] = HttpContext.Session.GetString("username");
            ViewData["password"] = HttpContext.Session.GetString("password");
            ViewData["agent"] = HttpContext.Session.GetString("username");
            ViewData["login"] = HttpContext.Session.GetString("login");
            login_status = HttpContext.Session.GetString("login");
            var _get_result = new get_result();
            var _value_result = _get_result.get_value(id);
            var status_result = false;
            foreach (var value in _value_result)
            {
                if (value.result == "คลอดแล้ว")
                {
                    status_result = true;
                    break;
                }
            }
            ViewData["ttt"] = status_result;
            ViewData["result"] = _value_result;
            if (login_status != "true")
            {
                return new RedirectToPageResult("/Index");
            }
            return Page();
        }
    }
}
