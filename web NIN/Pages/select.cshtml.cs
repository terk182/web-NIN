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
    public class selectModel : PageModel
    {
        public void OnGet()
        {
            ViewData["user"] = HttpContext.Session.GetString("username");



            ViewData["password"] = HttpContext.Session.GetString("password");
            ViewData["agent"] = HttpContext.Session.GetString("username");
            ViewData["login"] = HttpContext.Session.GetString("login");
            var _agent_data = new agent_data();

            ViewData["agent_list"] = _agent_data.get_value();
        }
    }
}
