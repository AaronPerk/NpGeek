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
            //Park park = new Park(); 
            //using (SqlConnection conn = new SqlConnection(connectionString))
            //{
            //    conn.Open();
            //    SqlCommand cmd = new SqlCommand ("SELECT", conn)
            //}
            throw new NotImplementedException();
        }

        public void SaveSurvey(Survey newSurvey)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO survey_result (parkCode, emailAddress, state, activityLevel) VALUES (@parkCode, @emailAddress, @state, @activityLevel", conn);
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
    }
}