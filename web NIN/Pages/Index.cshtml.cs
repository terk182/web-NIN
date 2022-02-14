using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Nancy.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using web_NIN.Models;
using web_NIN.Services;

namespace web_NIN.Pages
{
    public class IndexModel : PageModel
    {

        public void OnGet()
        {
            HttpContext.Session.SetString("username", "");
            HttpContext.Session.SetString("password", "");
            HttpContext.Session.SetString("login", "false");
            ViewData["agent"] = "";
        }

        [BindProperty]
        public Credential _Credential { get; set; }
        public string Message { get; set; } = "Initial Request";

        public IActionResult OnPost()
        {
            var url = "http://api06.fcc.co.th/api/Authenticate/login";

            var email = "";
            var fullmame = "";
            var username = "";
            var status = "";
            var message = "";
            var bu = "";

            var username_t = "";
            var password_t = "";
            var login_t = "";
            var httpRequest = (HttpWebRequest)WebRequest.Create(url);
            httpRequest.Method = "POST";
            token_class _token_class = new token_class();
            httpRequest.Accept = "application/json";
            httpRequest.ContentType = "application/json";

            Class_terk terk = new Class_terk();

            result_ad _result_ad = new result_ad();

            terk.username = "user";
            terk.password = "Password@123";
            var result_q = "";

            string json = new JavaScriptSerializer().Serialize(terk);
            using (var streamWriter = new StreamWriter(httpRequest.GetRequestStream()))
            {
                streamWriter.Write(json);
            }
            var json_reult = "";
            var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                var group_txt = "Project_NIN_Group";
                _token_class = JsonSerializer.Deserialize<token_class>(result);
                //textBox1.Text = _token_class.token;
                var admin = false;
                if(_Credential.type =="admin")
                {
                    group_txt = "Project_NIN_SUP_Group";
                    admin = true;
                }

                json_reult = check_ad(_token_class.token, _Credential.username, _Credential.password, group_txt);  //Project_KIA_Group
                                                                                                                             // textBox2.Text = json_reult;
                _result_ad = JsonSerializer.Deserialize<result_ad>(json_reult);
                email = _result_ad.email;
                fullmame = _result_ad.fullName;
                username = _result_ad.userName;
                bu = _result_ad.bu;
                ViewData["result"] = _result_ad.status.ToString();
                result_q = _result_ad.status.ToString();
                message = _result_ad.message;
                

                if (_result_ad.status == true)
                {
                    
                    var check_agent = new agent_service();
                    var terk_tt = check_agent.get_value(_Credential.username);
                    if(terk_tt.Count() > 0)
                    {
                        
                    }
                    else
                    {
                        var op = new agent_model();
                        op.operatorName = _Credential.username;
                        op.create_operator_name = _Credential.username;
                        var _insert_agent = new insert_agent();
                        _insert_agent.set_value(op);
                    }
                    HttpContext.Session.SetString("username", _Credential.username);
                    HttpContext.Session.SetString("password", _Credential.password);
                    HttpContext.Session.SetString("login","true");
                    if(admin == true)
                    {
                        return RedirectToPage("select");
                    }
                    else
                    {
                        return RedirectToPage("project");
                    }
                    
                }
                else
                {
                    HttpContext.Session.SetString("username", "");
                    HttpContext.Session.SetString("password", "");
                    HttpContext.Session.SetString("login", "false");
                    return RedirectToPage("Index");
                }





            }

        }


        public static string check_ad(string token_t, string usernae, string password, string group) //,string username,string password,string group
        {
            ad_model _ad_model = new ad_model();

            var url = "http://api06.fcc.co.th/api/ADAuthenticate/Authenticate";

            var httpRequest = (HttpWebRequest)WebRequest.Create(url);
            httpRequest.Method = "POST";

            httpRequest.Accept = "application/json";
            httpRequest.ContentType = "application/json"; //exception
            string Bearer_token = "Bearer ";
            Bearer_token += token_t;
            httpRequest.Headers["Authorization"] = Bearer_token;


            var result = "";
            _ad_model.username = usernae;
            _ad_model.password = password;
            _ad_model.group = group;
            //  "username": "CLA3050",
            // "password": "Kittim@#3050",
            //  "group": "Project_KIA_Group--"

            string json = new JavaScriptSerializer().Serialize(_ad_model);
            using (var streamWriter = new StreamWriter(httpRequest.GetRequestStream()))
            {
                streamWriter.Write(json);
            }

            var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                result = streamReader.ReadToEnd();
            }


            return result;
        }
        public class Credential
        {
            [Required]
            public string username { get; set; }
            [Required]
            [DataType(DataType.Password)]
            public string password { get; set; }
            [Required]
            public string type { get; set; }
        }
    }
}
