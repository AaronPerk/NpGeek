using Capstone.Web.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Capstone.Web.Models;

namespace Capstone.Web.Controllers
{
    public class HomeController : Controller
    {
        private IParkDAL parkDAL;

        public HomeController(IParkDAL parkDAL)
        {
            this.parkDAL = parkDAL;
        }

        // GET: Home
        public ActionResult Index()
        {
            if(Session["isCelsius"] == null)
            {
                Session["isCelsius"] = false;
            }

            List<Park> model = parkDAL.GetAllParks();

            return View("Index", model);
        }
        [ChildActionOnly]
        public ActionResult GetParks()
        {
            return PartialView("_ParksMenu", parkDAL.GetAllParks()); 
        }

        public ActionResult PageNotFound()
        {
            return View("PageNotFound"); 
        }
    }
}