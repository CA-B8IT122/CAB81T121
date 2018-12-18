using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TemplateExample.Controllers
{
    public class WineController : Controller
    {
        // GET: Wine
        public ActionResult Index()
        {
            return View();
        }

        // GET: Wine
        public ActionResult RedWine()
        {
            return View();
        }

        // GET: Wine
        public ActionResult WhiteWine()
        {
            return View();
        }


        // GET: Wine
        public ActionResult Rose()
        {
            return View();
        }

        // GET: Wine
        public ActionResult Sparkling()
        {
            return View();
        }
    }
}