using Capstone.Web.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Capstone.Web.DAL
{
    public class WeatherSqlDAL : IWeatherDAL
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["npgeek"].ConnectionString;

        public List <Weather> GetFiveDayForecast(string parkCode)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    List<Weather> forecast = new List<Weather>();

                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM weather WHERE parkCode = @parkCode");
                    cmd.Parameters.AddWithValue("parkCode", parkCode);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Weather weather = new Weather();
                        weather.ParkCode = Convert.ToString(reader["parkCode"]);
                        weather.FiveDayForecastValue = Convert.ToInt32(reader["fiveDayForcastValue"]);
                        weather.Forecast = Convert.ToString(reader["forecast"]);
                        weather.High = Convert.ToInt32(reader["high"]);
                        weather.Low = Convert.ToInt32(reader["low"]);
                        
                        if (weather.Forecast == "snow")
                        {
                            weather.WeatherRecommendation.Add("Oh the weather outside is frightful... You better pack snow shoes!");
                        }
                        else if (weather.Forecast == "rain")
                        {
                            weather.WeatherRecommendation.Add("It's rainy out there today! You should consider packing rain gear and waterproof shoes.");
                        }
                        else if (weather.Forecast == "thunderstorms")
                        {
                            weather.WeatherRecommendation.Add("Seek shelter and avoid hiking on exposed ridges!");
                        }
                        else if (weather.Forecast == "sunny")
                        {
                            weather.WeatherRecommendation.Add("It's bright and beautiful out side. You should consider packing sun block. ");
                        }
                        if (weather.High > 75)
                        {
                            weather.WeatherRecommendation.Add("It's going to be a scorcher! You better bring an extra gallon of water"); 
                        }
                        if ((weather.High - weather.Low) > 20)
                        {
                            weather.WeatherRecommendation.Add("Theres a lot of temperature variance today. I suggest you wear breathable layers.");
                        }
                        if (weather.Low < 20)
                        {
                            weather.WeatherRecommendation.Add("Frigid temperatures today and you don't want frostbite so put your fingers away. Dress to stay warm!");
                        }

                        forecast.Add(weather);

                    }
                    return forecast;
                }

            }
            catch (SqlException ex)
            {

                throw;
            }
        }
    }
}