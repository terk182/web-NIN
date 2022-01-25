using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace web_NIN.Services
{
    public class age_cal
    {
        
        public int Years;
        public int Months;
        public int Days;

        public age_cal(DateTime Bday)
        {
            this.Count(Bday);
        }

        public age_cal(DateTime Bday, DateTime Cday)
        {
            this.Count(Bday, Cday);
        }

        public age_cal Count(DateTime Bday)
        {
            return this.Count(Bday, DateTime.Today);
        }

        public age_cal Count(DateTime Bday, DateTime Cday)
        {
            if ((Cday.Year - Bday.Year) > 0 ||
                (((Cday.Year - Bday.Year) == 0) && ((Bday.Month < Cday.Month) ||
                  ((Bday.Month == Cday.Month) && (Bday.Day <= Cday.Day)))))
            {
                int DaysInBdayMonth = DateTime.DaysInMonth(Bday.Year, Bday.Month);
                int DaysRemain = Cday.Day + (DaysInBdayMonth - Bday.Day);

                if (Cday.Month > Bday.Month)
                {
                    this.Years = Cday.Year - Bday.Year;
                    this.Months = Cday.Month - (Bday.Month + 1) + Math.Abs(DaysRemain / DaysInBdayMonth);
                    this.Days = (DaysRemain % DaysInBdayMonth + DaysInBdayMonth) % DaysInBdayMonth;
                }
                else if (Cday.Month == Bday.Month)
                {
                    if (Cday.Day >= Bday.Day)
                    {
                        this.Years = Cday.Year - Bday.Year;
                        this.Months = 0;
                        this.Days = Cday.Day - Bday.Day;
                    }
                    else
                    {
                        this.Years = (Cday.Year - 1) - Bday.Year;
                        this.Months = 11;
                        this.Days = DateTime.DaysInMonth(Bday.Year, Bday.Month) - (Bday.Day - Cday.Day);
                    }
                }
                else
                {
                    this.Years = (Cday.Year - 1) - Bday.Year;
                    this.Months = Cday.Month + (11 - Bday.Month) + Math.Abs(DaysRemain / DaysInBdayMonth);
                    this.Days = (DaysRemain % DaysInBdayMonth + DaysInBdayMonth) % DaysInBdayMonth;
                }
            }
            else
            {
                return this;
            }
            return this;
        }


        public int count_bday(DateTime Bday)
        {
            var nextDate = Bday;
            var today = DateTime.Now;

            //get difference of two dates
            var diffOfDates = nextDate - today;

            var ddd = 0;
            var date_t = diffOfDates.Days;
            if (date_t < 0)
            {
                ddd = 280 + Math.Abs(date_t);
            }
            else
            {
                ddd =   280 - date_t;
            }

            var fff = ddd;


            return fff;
        }
    }

}

