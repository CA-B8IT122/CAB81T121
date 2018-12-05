using Q2_2018.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Q2_2018.Controllers
{
    public class HomeController : Controller
    {
        static List<BuildingCodes> buildingcode = new List<BuildingCodes>();

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(BuildingCodes bc)
        {
            
                buildingcode.Add(bc);
                return View("ShowCodes", buildingcode) ;

        }

    }
}
