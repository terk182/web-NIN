using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace web_NIN.Services
{
    public class get_date_1_31
    {
        public  List<string> Get_value()
        {
            var date_list = new List<string>();
            var _calendar_service = new calendar_service();
            var data = _calendar_service.get_value("2021-06");
            string[] date_check = new string[32];

            for (int i = 0; i < 32; i++)
            {
                if (i < 10)
                {
                    date_list.Add ( "0" + i.ToString());
                }
                else
                {
                    date_list.Add(date_check[i] = i.ToString());
                }

            }

            //var dat_loop = date_check.Where((source, index) => index != 0).ToArray();
            return date_list;
        }
    }
}
