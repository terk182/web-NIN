using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using web_NIN.Models;
using web_NIN.Services;

namespace web_NIN.Pages
{
    public class assignModel : PageModel
    {
        public void OnGet()
        {
            var _calendar_service = new calendar_service();
            string[] nnnnnn_check = new string[13];
            for (int ir = 0; ir < 13; ir++)
            {
                if (ir < 10)
                {
                    nnnnnn_check[ir] = "0" + ir.ToString();
                }
                else
                {
                    nnnnnn_check[ir] = ir.ToString();
                }

            }
            string[] date_check = new string[32];
            var _mmmm = nnnnnn_check;
            var dat_loop_m = _mmmm.Where((source, index) => index != 0).ToArray();

            var _event_set = new events_set();
            var _events_list = new List<event_sub>();
            var _get_calendar_result_model = new List<get_calendar_result_model>();


            for (int i = 0; i < 32; i++)
            {
                if (i < 10)
                {
                    date_check[i] = "0" + i.ToString();
                }
                else
                {
                    date_check[i] = i.ToString();
                }

            }


            var dat_loop = date_check.Where((source, index) => index != 0).ToArray();

            var m_t = "";
            for (int ih = 0; ih < dat_loop_m.Length; ih++)
            {
                m_t = dat_loop_m[ih];
  
                var yyyyy = "2021-" + dat_loop_m[ih];

                var data = _calendar_service.get_value(yyyyy);
               if(data.Count() <1)
                {
                    continue;
                }
                int count_date = 0;
                var date_mane = "";
                var m_mane = "";
                var d_mane = "";
                var toggle = false;
                for (int i = 0; i < dat_loop.Length; i++)
                {
                    count_date = 0;
                    date_mane = "";
                    m_mane = "";
                    d_mane = "";
                    toggle = false;
                    foreach (var value in data)
                    {

                        string[] date_sub = value.tbGigya_registerDate.Split('-');
                        if (dat_loop[i] == date_sub[0])
                        {
                            if (toggle == false)
                            {
                                date_mane = yyyyy+"-"+ dat_loop[i];
                                m_mane = dat_loop_m[ih];
                                d_mane = dat_loop[i];
                                toggle = true;
                            }

                            count_date++;
                        }

                    }

                    if (string.IsNullOrEmpty(date_mane))
                    {

                    }
                    else
                    {
                        //string[] date_sub11 = date_mane.Split('-');

                        _get_calendar_result_model.Add(new get_calendar_result_model
                        {
                            mmm = date_mane,
                            count_ = count_date,
                            d = d_mane,
                            m = m_mane,
                            y = "2021",
                            

                        }
                            );
                    }
                    count_date = 0;
                    date_mane = "";
                    m_mane = "";
                    d_mane = "";
                    toggle = false;

                }

               


            }

            var tttt = _get_calendar_result_model;
            foreach (var value1 in tttt)
            {
                _events_list.Add(new event_sub
                {
                    title = value1.count_.ToString(),
                    start = value1.mmm,
                    d = value1.d,
                    m = value1.m,
                    y = value1.y,
                    url = "admin?date="+ value1.mmm
                }
                    );



            }


            ViewData["FieldsList"] = _events_list;
         //   var tttttt = new JsonResult(_event_setresult);
        }
    }
}
