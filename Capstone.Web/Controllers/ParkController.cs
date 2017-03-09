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
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Detail(string parkCode)
        {
            if(parkCode == "" || parkCode == null)
            {
                return RedirectToAction("Index", "Home");
            }

            Park model = parkDAL.GetPark(parkCode);

            return View("Detail", model);
        }
    }
}