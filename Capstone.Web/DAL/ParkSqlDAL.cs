using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Capstone.Web.DAL;
using Capstone.Web.Models;

namespace Capstone.Web.DAL
{
    public class ParkSqlDAL : IParkDAL
    {
        public List<Park> GetAllParks()
        {
            throw new NotImplementedException();
        }

        public Park GetPark(string parkCode)
        {
            throw new NotImplementedException();
        }

        public Park GetSurveyLeader()
        {
            throw new NotImplementedException();
        }

        public void SaveSurvey(Survey newSurvey)
        {
            throw new NotImplementedException();
        }
    }
}