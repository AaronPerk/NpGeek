using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Capstone.Web.Models
{
    public class Weather
    {
        string ParkCode { get; set; }
        int FiveDayForecastValue { get; set; }
        int Low { get; set; }
        int High { get; set; }
        string Forecast { get; set; }
    }
}