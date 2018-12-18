using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TemplateExample.Controllers
{
    public class MemberController : Controller
    {
        // GET: About
        public ActionResult Index()
        {
            return View();
        }
    }
}