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
        public int Low { get; set; }
        public int High { get; set; }
        public string Forecast { get; set; }
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
    }

}