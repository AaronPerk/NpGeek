using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Capstone.Web.DAL;
using Capstone.Web.Models;
using System.Data.SqlClient;
using System.Configuration;

namespace Capstone.Web.DAL
{
    public class ParkSqlDAL : IParkDAL
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["npgeek"].ConnectionString;

        public List<Park> GetAllParks()
        {
            List<Park> parks = new List<Park>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM park", conn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Park park = new Park();
                        park.ParkCode = Convert.ToString(reader["parkCode"]);
                        park.ParkName = Convert.ToString(reader["parkName"]);
                        park.State = Convert.ToString(reader["State"]);
                        park.Acreage = Convert.ToInt32(reader["Acreage"]);
                        park.ElevationInFeet = Convert.ToInt32(reader["ElevationInFeet"]);
                        park.MilesOfTrail = Convert.ToDouble(reader["MilesOfTrail"]);
                        park.NumberOfCampsites = Convert.ToInt32(reader["NumberOfCampsites"]);
                        park.Climate = Convert.ToString(reader["Climate"]);
                        park.YearFounded = Convert.ToInt32(reader["YearFounded"]);
                        park.ElevationInFeet = Convert.ToInt32(reader["ElevationInFeet"]);
                        park.AnnualVisitorCount = Convert.ToInt32(reader["AnnualVisitorCount"]);
                        park.InspirationalQuote = Convert.ToString(reader["InspirationalQuote"]);
                        park.InspirationalQuoteSource = Convert.ToString(reader["InspirationalQuoteSource"]);
                        park.ParkDescription = Convert.ToString(reader["ParkDescription"]);
                        park.EntryFee = Convert.ToInt32(reader["EntryFee"]);
                        park.NumberOfAnimalSpecies = Convert.ToInt32(reader["NumberOfAnimalSpecies"]);
                        parks.Add(park); 
                        
                    }

                }
            }
            catch (SqlException ex)
            {

                throw;
            }
            return parks;
        }

        public Park GetPark(string parkCode)
        {
            Park park = new Park(); 
            try
            {
                using(SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("Select * From Park WHERE parkCode = @parkCode ", conn);
                    cmd.Parameters.AddWithValue("@parkCode", parkCode);
                    SqlDataReader reader = cmd.ExecuteReader(); 

                    while (reader.Read())
                    {
                        park.ParkCode = Convert.ToString(reader["parkCode"]);
                        park.ParkName = Convert.ToString(reader["parkName"]);
                        park.State = Convert.ToString(reader["State"]);
                        park.Acreage = Convert.ToInt32(reader["Acreage"]);
                        park.ElevationInFeet = Convert.ToInt32(reader["ElevationInFeet"]);
                        park.MilesOfTrail = Convert.ToDouble(reader["MilesOfTrail"]);
                        park.NumberOfCampsites = Convert.ToInt32(reader["NumberOfCampsites"]);
                        park.Climate = Convert.ToString(reader["Climate"]);
                        park.YearFounded = Convert.ToInt32(reader["YearFounded"]);
                        park.ElevationInFeet = Convert.ToInt32(reader["ElevationInFeet"]);
                        park.AnnualVisitorCount = Convert.ToInt32(reader["AnnualVisitorCount"]);
                        park.InspirationalQuote = Convert.ToString(reader["InspirationalQuote"]);
                        park.InspirationalQuoteSource = Convert.ToString(reader["InspirationalQuoteSource"]);
                        park.ParkDescription = Convert.ToString(reader["ParkDescription"]);
                        park.EntryFee = Convert.ToInt32(reader["EntryFee"]);
                        park.NumberOfAnimalSpecies = Convert.ToInt32(reader["NumberOfAnimalSpecies"]);
                        return park; 
                    }
                   
                }
            }
            catch (Exception)
            {

                throw;
            }
            return null; 
        }

        public Park GetSurveyLeader()
        {
            Park park = new Park();
            string parkCode = "";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT TOP 1 parkCode, COUNT(*) FROM survey_result GROUP BY parkCode ORDER BY COUNT(*) DESC", conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    parkCode = Convert.ToString(reader["parkCode"]);
                }
            }
            park = GetPark(parkCode);
            return park;
        }

        public void SaveSurvey(Survey newSurvey)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO survey_result (parkCode, emailAddress, state, activityLevel) VALUES (@parkCode, @emailAddress, @state, @activityLevel)", conn);
                    cmd.Parameters.AddWithValue("@parkCode", newSurvey.ParkCode); 
                    cmd.Parameters.AddWithValue("@emailAddress", newSurvey.EmailAddress);
                    cmd.Parameters.AddWithValue("@state", newSurvey.State);
                    cmd.Parameters.AddWithValue("@activityLevel", newSurvey.ActivityLevel);
                    cmd.ExecuteNonQuery(); 
                }

            }
            catch (SqlException e)
            {

                throw;
            }
        }
        public List<Weather> GetFiveDayForecast(string parkCode)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    List<Weather> forecast = new List<Weather>();

                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM weather WHERE parkCode = @parkCode", conn);
                    cmd.Parameters.AddWithValue("parkCode", parkCode);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Weather weather = new Weather();
                        weather.ParkCode = Convert.ToString(reader["parkCode"]);
                        weather.FiveDayForecastValue = Convert.ToInt32(reader["fiveDayForecastValue"]);
                        weather.Forecast = Convert.ToString(reader["forecast"]);
                        weather.High = Convert.ToInt32(reader["high"]);
                        weather.Low = Convert.ToInt32(reader["low"]);
                        weather.IsCelcius = false;
                        weather.WeatherRecommendation = new List<string>(); 

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

