using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GrapeWine.Models;

namespace GrapeWine.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order
        public ActionResult Index()
        {
            return View();
        }

        DAO dao = new DAO();


        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult PlaceOrder(Order order)
        {
            int counter = 0;
            counter = dao.InsertOrder(order);
            if (counter == 1)
            {
                Response.Write("Book purchased");
                ModelState.Clear();
            }
            else
                Response.Write("Error, " + dao.message);

            return View();
        }
    }
}