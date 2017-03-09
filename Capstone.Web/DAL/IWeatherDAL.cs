using Capstone.Web.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Capstone.Web.DAL
{
    public interface IWeatherDAL
    {
        List<Weather> GetFiveDayForecast(string parkCode); 
    }
}