using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using web_NIN.Models;
using web_NIN.Services;

namespace web_NIN.Pages
{
    public class assign_babyModel : PageModel
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
            var _get_baby_date = new get_baby_date();
            var result = _get_baby_date.get_baby();
            int result_n ;
            var baby_model_1 = new List<baby_model>();
            var baby_day1 = new List<baby_model>();
            var baby_day2 = new List<baby_model>();
            var baby_day3 = new List<baby_model>();
            var baby_day4 = new List<baby_model>();
            var baby_day5 = new List<baby_model>();
            var baby_day6 = new List<baby_model>();
            var baby_day7 = new List<baby_model>();
            var baby_day8 = new List<baby_model>();
            var baby_day9 = new List<baby_model>();
            var baby_day10 = new List<baby_model>();
            var baby_day11 = new List<baby_model>();
            var baby_day12 = new List<baby_model>();
            var baby_day13 = new List<baby_model>();
            var baby_day14 = new List<baby_model>();
            var baby_day15 = new List<baby_model>();
            var baby_day16 = new List<baby_model>();
            var baby_day17 = new List<baby_model>();
            var baby_day18 = new List<baby_model>();
            var baby_day19 = new List<baby_model>();
            var baby_day20 = new List<baby_model>();
            var baby_day21 = new List<baby_model>();
            var baby_day22 = new List<baby_model>();
            var baby_day23 = new List<baby_model>();
            var baby_day24 = new List<baby_model>();
            var baby_day25 = new List<baby_model>();
            var baby_day26 = new List<baby_model>();
            var baby_day27 = new List<baby_model>();
            var baby_day28 = new List<baby_model>();
            var baby_day29 = new List<baby_model>();
            var baby_day30 = new List<baby_model>();
            foreach (var value in result)
            {
                if(String.IsNullOrEmpty(value.day))
                {
                    
                    
                }
                else
                {
                    result_n = Int32.Parse(value.day);
                    if(result_n < 31 && result_n >0)
                    {



                        baby_model_1.Add(new baby_model {
                        profile_firstName = value.profile_firstName,
                        profile_lastName = value.profile_lastName,
                        tbGigya_registerDate = value.tbGigya_registerDate,
                        profile_mobile = value.profile_mobile,
                        profile_email = value.profile_email,
                        crm_childBirthDate_used = value.crm_childBirthDate_used,
                        tbCRM_id = value.tbCRM_id,
                        day = value.day
                        });

                        switch (result_n)
                        {
                            case 1:
                                baby_day1.Add(new baby_model
                                {
                                    profile_firstName = value.profile_firstName,
                                    profile_lastName = value.profile_lastName,
                                    tbGigya_registerDate = value.tbGigya_registerDate,
                                    profile_mobile = value.profile_mobile,
                                    profile_email = value.profile_email,
                                    crm_childBirthDate_used = value.crm_childBirthDate_used,
                                    tbCRM_id = value.tbCRM_id,
                                    day = value.day
                                });
                                break;
                            case 2:
                                baby_day2.Add(new baby_model
                                {
                                    profile_firstName = value.profile_firstName,
                                    profile_lastName = value.profile_lastName,
                                    tbGigya_registerDate = value.tbGigya_registerDate,
                                    profile_mobile = value.profile_mobile,
                                    profile_email = value.profile_email,
                                    crm_childBirthDate_used = value.crm_childBirthDate_used,
                                    tbCRM_id = value.tbCRM_id,
                                    day = value.day
                                });
                                break;
                            case 3:
                                baby_day3.Add(new baby_model
                                {
                                    profile_firstName = value.profile_firstName,
                                    profile_lastName = value.profile_lastName,
                                    tbGigya_registerDate = value.tbGigya_registerDate,
                                    profile_mobile = value.profile_mobile,
                                    profile_email = value.profile_email,
                                    crm_childBirthDate_used = value.crm_childBirthDate_used,
                                    tbCRM_id = value.tbCRM_id,
                                    day = value.day
                                });
                                break;
                            case 4:
                                baby_day4.Add(new baby_model
                                {
                                    profile_firstName = value.profile_firstName,
                                    profile_lastName = value.profile_lastName,
                                    tbGigya_registerDate = value.tbGigya_registerDate,
                                    profile_mobile = value.profile_mobile,
                                    profile_email = value.profile_email,
                                    crm_childBirthDate_used = value.crm_childBirthDate_used,
                                    tbCRM_id = value.tbCRM_id,
                                    day = value.day
                                });
                                break;
                            case 5:
                                baby_day5.Add(new baby_model
                                {
                                    profile_firstName = value.profile_firstName,
                                    profile_lastName = value.profile_lastName,
                                    tbGigya_registerDate = value.tbGigya_registerDate,
                                    profile_mobile = value.profile_mobile,
                                    profile_email = value.profile_email,
                                    crm_childBirthDate_used = value.crm_childBirthDate_used,
                                    tbCRM_id = value.tbCRM_id,
                                    day = value.day
                                });
                                break;
                            case 6:
                                baby_day6.Add(new baby_model
                                {
                                    profile_firstName = value.profile_firstName,
                                    profile_lastName = value.profile_lastName,
                                    tbGigya_registerDate = value.tbGigya_registerDate,
                                    profile_mobile = value.profile_mobile,
                                    profile_email = value.profile_email,
                                    crm_childBirthDate_used = value.crm_childBirthDate_used,
                                    tbCRM_id = value.tbCRM_id,
                                    day = value.day
                                });
                                break;
                            case 7:
                                baby_day7.Add(new baby_model
                                {
                                    profile_firstName = value.profile_firstName,
                                    profile_lastName = value.profile_lastName,
                                    tbGigya_registerDate = value.tbGigya_registerDate,
                                    profile_mobile = value.profile_mobile,
                                    profile_email = value.profile_email,
                                    crm_childBirthDate_used = value.crm_childBirthDate_used,
                                    tbCRM_id = value.tbCRM_id,
                                    day = value.day
                                });
                                break;
                            case 8:
                                baby_day8.Add(new baby_model
                                {
                                    profile_firstName = value.profile_firstName,
                                    profile_lastName = value.profile_lastName,
                                    tbGigya_registerDate = value.tbGigya_registerDate,
                                    profile_mobile = value.profile_mobile,
                                    profile_email = value.profile_email,
                                    crm_childBirthDate_used = value.crm_childBirthDate_used,
                                    tbCRM_id = value.tbCRM_id,
                                    day = value.day
                                });
                                break;
                            case 9:
                                baby_day9.Add(new baby_model
                                {
                                    profile_firstName = value.profile_firstName,
                                    profile_lastName = value.profile_lastName,
                                    tbGigya_registerDate = value.tbGigya_registerDate,
                                    profile_mobile = value.profile_mobile,
                                    profile_email = value.profile_email,
                                    crm_childBirthDate_used = value.crm_childBirthDate_used,
                                    tbCRM_id = value.tbCRM_id,
                                    day = value.day
                                });
                                break;
                            case 10:
                                baby_day10.Add(new baby_model
                                {
                                    profile_firstName = value.profile_firstName,
                                    profile_lastName = value.profile_lastName,
                                    tbGigya_registerDate = value.tbGigya_registerDate,
                                    profile_mobile = value.profile_mobile,
                                    profile_email = value.profile_email,
                                    crm_childBirthDate_used = value.crm_childBirthDate_used,
                                    tbCRM_id = value.tbCRM_id,
                                    day = value.day
                                });
                                break;
                            case 11:
                                baby_day11.Add(new baby_model
                                {
                                    profile_firstName = value.profile_firstName,
                                    profile_lastName = value.profile_lastName,
                                    tbGigya_registerDate = value.tbGigya_registerDate,
                                    profile_mobile = value.profile_mobile,
                                    profile_email = value.profile_email,
                                    crm_childBirthDate_used = value.crm_childBirthDate_used,
                                    tbCRM_id = value.tbCRM_id,
                                    day = value.day
                                });
                                break;
                            case 12:
                                baby_day12.Add(new baby_model
                                {
                                    profile_firstName = value.profile_firstName,
                                    profile_lastName = value.profile_lastName,
                                    tbGigya_registerDate = value.tbGigya_registerDate,
                                    profile_mobile = value.profile_mobile,
                                    profile_email = value.profile_email,
                                    crm_childBirthDate_used = value.crm_childBirthDate_used,
                                    tbCRM_id = value.tbCRM_id,
                                    day = value.day
                                });
                                break;
                            case 13:
                                baby_day13.Add(new baby_model
                                {
                                    profile_firstName = value.profile_firstName,
                                    profile_lastName = value.profile_lastName,
                                    tbGigya_registerDate = value.tbGigya_registerDate,
                                    profile_mobile = value.profile_mobile,
                                    profile_email = value.profile_email,
                                    crm_childBirthDate_used = value.crm_childBirthDate_used,
                                    tbCRM_id = value.tbCRM_id,
                                    day = value.day
                                });
                                break;
                            case 14:
                                baby_day14.Add(new baby_model
                                {
                                    profile_firstName = value.profile_firstName,
                                    profile_lastName = value.profile_lastName,
                                    tbGigya_registerDate = value.tbGigya_registerDate,
                                    profile_mobile = value.profile_mobile,
                                    profile_email = value.profile_email,
                                    crm_childBirthDate_used = value.crm_childBirthDate_used,
                                    tbCRM_id = value.tbCRM_id,
                                    day = value.day
                                });
                                break;
                            case 15:
                                baby_day15.Add(new baby_model
                                {
                                    profile_firstName = value.profile_firstName,
                                    profile_lastName = value.profile_lastName,
                                    tbGigya_registerDate = value.tbGigya_registerDate,
                                    profile_mobile = value.profile_mobile,
                                    profile_email = value.profile_email,
                                    crm_childBirthDate_used = value.crm_childBirthDate_used,
                                    tbCRM_id = value.tbCRM_id,
                                    day = value.day
                                });
                                break;
                            case 16:
                                baby_day16.Add(new baby_model
                                {
                                    profile_firstName = value.profile_firstName,
                                    profile_lastName = value.profile_lastName,
                                    tbGigya_registerDate = value.tbGigya_registerDate,
                                    profile_mobile = value.profile_mobile,
                                    profile_email = value.profile_email,
                                    crm_childBirthDate_used = value.crm_childBirthDate_used,
                                    tbCRM_id = value.tbCRM_id,
                                    day = value.day
                                });
                                break;
                            case 17:
                                baby_day17.Add(new baby_model
                                {
                                    profile_firstName = value.profile_firstName,
                                    profile_lastName = value.profile_lastName,
                                    tbGigya_registerDate = value.tbGigya_registerDate,
                                    profile_mobile = value.profile_mobile,
                                    profile_email = value.profile_email,
                                    crm_childBirthDate_used = value.crm_childBirthDate_used,
                                    tbCRM_id = value.tbCRM_id,
                                    day = value.day
                                });
                                break;
                            case 18:
                                baby_day18.Add(new baby_model
                                {
                                    profile_firstName = value.profile_firstName,
                                    profile_lastName = value.profile_lastName,
                                    tbGigya_registerDate = value.tbGigya_registerDate,
                                    profile_mobile = value.profile_mobile,
                                    profile_email = value.profile_email,
                                    crm_childBirthDate_used = value.crm_childBirthDate_used,
                                    tbCRM_id = value.tbCRM_id,
                                    day = value.day
                                });
                                break;
                            case 19:
                                baby_day19.Add(new baby_model
                                {
                                    profile_firstName = value.profile_firstName,
                                    profile_lastName = value.profile_lastName,
                                    tbGigya_registerDate = value.tbGigya_registerDate,
                                    profile_mobile = value.profile_mobile,
                                    profile_email = value.profile_email,
                                    crm_childBirthDate_used = value.crm_childBirthDate_used,
                                    tbCRM_id = value.tbCRM_id,
                                    day = value.day
                                });
                                break;
                            case 20:
                                baby_day20.Add(new baby_model
                                {
                                    profile_firstName = value.profile_firstName,
                                    profile_lastName = value.profile_lastName,
                                    tbGigya_registerDate = value.tbGigya_registerDate,
                                    profile_mobile = value.profile_mobile,
                                    profile_email = value.profile_email,
                                    crm_childBirthDate_used = value.crm_childBirthDate_used,
                                    tbCRM_id = value.tbCRM_id,
                                    day = value.day
                                });
                                break;
                            case 21:
                                baby_day21.Add(new baby_model
                                {
                                    profile_firstName = value.profile_firstName,
                                    profile_lastName = value.profile_lastName,
                                    tbGigya_registerDate = value.tbGigya_registerDate,
                                    profile_mobile = value.profile_mobile,
                                    profile_email = value.profile_email,
                                    crm_childBirthDate_used = value.crm_childBirthDate_used,
                                    tbCRM_id = value.tbCRM_id,
                                    day = value.day
                                });
                                break;
                            case 22:
                                baby_day22.Add(new baby_model
                                {
                                    profile_firstName = value.profile_firstName,
                                    profile_lastName = value.profile_lastName,
                                    tbGigya_registerDate = value.tbGigya_registerDate,
                                    profile_mobile = value.profile_mobile,
                                    profile_email = value.profile_email,
                                    crm_childBirthDate_used = value.crm_childBirthDate_used,
                                    tbCRM_id = value.tbCRM_id,
                                    day = value.day
                                });
                                break;
                            case 23:
                                baby_day23.Add(new baby_model
                                {
                                    profile_firstName = value.profile_firstName,
                                    profile_lastName = value.profile_lastName,
                                    tbGigya_registerDate = value.tbGigya_registerDate,
                                    profile_mobile = value.profile_mobile,
                                    profile_email = value.profile_email,
                                    crm_childBirthDate_used = value.crm_childBirthDate_used,
                                    tbCRM_id = value.tbCRM_id,
                                    day = value.day
                                });
                                break;
                            case 24:
                                baby_day24.Add(new baby_model
                                {
                                    profile_firstName = value.profile_firstName,
                                    profile_lastName = value.profile_lastName,
                                    tbGigya_registerDate = value.tbGigya_registerDate,
                                    profile_mobile = value.profile_mobile,
                                    profile_email = value.profile_email,
                                    crm_childBirthDate_used = value.crm_childBirthDate_used,
                                    tbCRM_id = value.tbCRM_id,
                                    day = value.day
                                });
                                break;
                            case 25:
                                baby_day25.Add(new baby_model
                                {
                                    profile_firstName = value.profile_firstName,
                                    profile_lastName = value.profile_lastName,
                                    tbGigya_registerDate = value.tbGigya_registerDate,
                                    profile_mobile = value.profile_mobile,
                                    profile_email = value.profile_email,
                                    crm_childBirthDate_used = value.crm_childBirthDate_used,
                                    tbCRM_id = value.tbCRM_id,
                                    day = value.day
                                });
                                break;
                            case 26:
                                baby_day26.Add(new baby_model
                                {
                                    profile_firstName = value.profile_firstName,
                                    profile_lastName = value.profile_lastName,
                                    tbGigya_registerDate = value.tbGigya_registerDate,
                                    profile_mobile = value.profile_mobile,
                                    profile_email = value.profile_email,
                                    crm_childBirthDate_used = value.crm_childBirthDate_used,
                                    tbCRM_id = value.tbCRM_id,
                                    day = value.day
                                });
                                break;
                            case 27:
                                baby_day27.Add(new baby_model
                                {
                                    profile_firstName = value.profile_firstName,
                                    profile_lastName = value.profile_lastName,
                                    tbGigya_registerDate = value.tbGigya_registerDate,
                                    profile_mobile = value.profile_mobile,
                                    profile_email = value.profile_email,
                                    crm_childBirthDate_used = value.crm_childBirthDate_used,
                                    tbCRM_id = value.tbCRM_id,
                                    day = value.day
                                });
                                break;
                            case 28:
                                baby_day28.Add(new baby_model
                                {
                                    profile_firstName = value.profile_firstName,
                                    profile_lastName = value.profile_lastName,
                                    tbGigya_registerDate = value.tbGigya_registerDate,
                                    profile_mobile = value.profile_mobile,
                                    profile_email = value.profile_email,
                                    crm_childBirthDate_used = value.crm_childBirthDate_used,
                                    tbCRM_id = value.tbCRM_id,
                                    day = value.day
                                });
                                break;
                            case 29:
                                baby_day29.Add(new baby_model
                                {
                                    profile_firstName = value.profile_firstName,
                                    profile_lastName = value.profile_lastName,
                                    tbGigya_registerDate = value.tbGigya_registerDate,
                                    profile_mobile = value.profile_mobile,
                                    profile_email = value.profile_email,
                                    crm_childBirthDate_used = value.crm_childBirthDate_used,
                                    tbCRM_id = value.tbCRM_id,
                                    day = value.day
                                });
                                break;
                            case 30:
                                baby_day30.Add(new baby_model
                                {
                                    profile_firstName = value.profile_firstName,
                                    profile_lastName = value.profile_lastName,
                                    tbGigya_registerDate = value.tbGigya_registerDate,
                                    profile_mobile = value.profile_mobile,
                                    profile_email = value.profile_email,
                                    crm_childBirthDate_used = value.crm_childBirthDate_used,
                                    tbCRM_id = value.tbCRM_id,
                                    day = value.day
                                });
                                break;
                            default:
                                // code block
                                break;
                        }
                    }
                }
                
            }
            ViewData["baby_day_t"] = baby_model_1;
            ViewData["baby_day1"] = baby_day1;
            ViewData["baby_day1"] = baby_day2;
            ViewData["baby_day1"] = baby_day3;
            ViewData["baby_day1"] = baby_day4;
            ViewData["baby_day1"] = baby_day5;
            ViewData["baby_day1"] = baby_day6;
            ViewData["baby_day1"] = baby_day7;
            ViewData["baby_day1"] = baby_day8;
            ViewData["baby_day1"] = baby_day9;
            ViewData["baby_day1"] = baby_day10;
            ViewData["baby_day1"] = baby_day11;
            ViewData["baby_day1"] = baby_day12;
            ViewData["baby_day1"] = baby_day13;
            ViewData["baby_day1"] = baby_day14;
            ViewData["baby_day1"] = baby_day15;
            ViewData["baby_day1"] = baby_day16;
            ViewData["baby_day1"] = baby_day17;
            ViewData["baby_day1"] = baby_day18;
            ViewData["baby_day1"] = baby_day19;
            ViewData["baby_day1"] = baby_day20;
            ViewData["baby_day1"] = baby_day21;
            ViewData["baby_day1"] = baby_day22;
            ViewData["baby_day1"] = baby_day23;
            ViewData["baby_day1"] = baby_day24;
            ViewData["baby_day1"] = baby_day25;
            ViewData["baby_day1"] = baby_day26;
            ViewData["baby_day1"] = baby_day27;
            ViewData["baby_day1"] = baby_day28;
            ViewData["baby_day1"] = baby_day29;
            ViewData["baby_day1"] = baby_day30;

            if (login_status != "true")
            {
                return new RedirectToPageResult("/Index");
            }
            return Page();
        }

        [HttpGet]
        public IActionResult OnGetAssign(string agen_id, string list, string num) //Assign
        {
            string[] mom_id_list = list.Split(',');
            var buck = new List<RequestObj>();
            var usser = HttpContext.Session.GetString("username");
            var _customer_data = new get_customer_by_id();
            var data = new customer();
            for (int i = 0; i < mom_id_list.Length; i++)
            {
                data = _customer_data.get_value(mom_id_list[i]);
                buck.Add(new RequestObj
                {
                    custommerID = mom_id_list[i],
                    operatorID = agen_id,
                    create_operator_name = usser,
                    replece = "0",
                    phone = data.phone,
                    custommer_name = data.name +" "+ data.lname,


                });
            }


            var _update_to_new_assign_all = new insert_assign_3();
            _update_to_new_assign_all.set_value(buck);

            var _update_to_assign_Unreachable = new update_to_assign_buck();
            _update_to_assign_Unreachable.set_value(buck, agen_id);

            return new JsonResult(agen_id);
        }
    }

    
}
