using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Capstone.Web.Models
{
    public class Weather
    {
        public string ParkCode { get; set; }
        public int FiveDayForecastValue { get; set; }
        private int low;
        public int Low
        {
            get
            {
                return Convert(low);
            }

            set { low = value; }
        }
        private int high;
        public int High
        {
            get
            {
                return Convert(high);
            }

            set { high = value; }
        }

        public string Forecast { get; set; }
        public bool IsCelcius { get; set; }
        public List<string> WeatherRecommendation { get; set; }

        public string DayOfWeek(int fiveDayForcastValue)
        {
            if (fiveDayForcastValue == 1)
            {
                return "Monday"; 
            }
            else if (fiveDayForcastValue == 2)
            {
                return "Tuesday";
            }
            else if (fiveDayForcastValue == 3)
            {
                return "Wednesday";
            }
            else if (fiveDayForcastValue == 4)
            {
                return "Thursday";
            }
            else if (fiveDayForcastValue == 5)
            {
                return "Friday";
            }
            return ""; 
        }

        private int Convert(int highOrLow)
        {
            double temp = highOrLow;

            if (IsCelcius)
            {
                double multiplier = 5.0 / 9.0;

                temp = ((temp - 32) * multiplier);

                return (int)temp;
            }

            return (int)temp;
        }
    }

}