using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Capstone.Web.DAL;
using Capstone.Web.Models;

namespace Capstone.Web.Controllers
{
    public class ParkController : Controller
    {
        private IParkDAL parkDAL;

        public ParkController(IParkDAL parkDAL)
        {
            this.parkDAL = parkDAL;
        }
        
        // GET: Park
        public ActionResult Index()
        {

            if (Session["isCelsius"] == null)
            {
                Session["isCelsius"] = false;
            }

            return RedirectToAction("Index", "Home");
        }

        public ActionResult Detail(string parkCode)
        {
            if (Session["isCelsius"] == null)
            {
                Session["isCelsius"] = false;
            }

            if (parkCode == "" || parkCode == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else if (parkDAL.GetPark(parkCode) == null)
            {
                return RedirectToAction("PageNotFound", "Home");
                //return httpnotfound(); <--this will return the 404 page
                //This allows you to set the web config to direct them to a different URL (look at exception not found website) 
            }

            Park model = parkDAL.GetPark(parkCode);
            model.Forecast = parkDAL.GetFiveDayForecast(parkCode); 
            model.SwitchDegrees(Convert.ToBoolean(Session["isCelsius"]));

            return View("Detail", model);
        }

        [HttpPost]
        public ActionResult Detail(bool Celsius, string parkCode)
        {
            if (Celsius)
            {
                Session["isCelsius"] = true;
            }
            else
            {
                Session["isCelsius"] = false;
            }

            return RedirectToAction("Detail", "Park", new { parkCode });
        }
        
        public ActionResult Survey()
        {
            return View("Survey");

        }
        [HttpPost]
        public ActionResult Survey(Survey survey)
        {
            if(!ModelState.IsValid)
            {
                return View("Survey", survey); 
            }
            parkDAL.SaveSurvey(survey); 
            return RedirectToAction("SurveyResult", "Park"); 
        }
        public ActionResult SurveyResult()
        {
            Park model = parkDAL.GetSurveyLeader(); 

            return View("SurveyResult",model);
        }



    }
}