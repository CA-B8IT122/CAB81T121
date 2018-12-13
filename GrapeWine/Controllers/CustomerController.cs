using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GrapeWine.Models;
using System.Web.Helpers;

namespace GrapeWine.Controllers
{
    public class CustomerController : Controller
    {
        DAO dao = new DAO();

        // GET: Customer
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AddCustomer()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCustomer(Customer cust)
        {
            int counter = 0;

            counter = dao.InsertCustomer(cust);
            if (counter == 1)
            {
                Response.Write("Customer successfully added");
                ModelState.Clear();
            }
            else
            {
                Response.Write("Error in home controller " + dao);
            }
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Customer cust)
        {

            ModelState.Remove("CustName");
            ModelState.Remove("StreetAddress");
            ModelState.Remove("ConfirmPassword");
            if (ModelState.IsValid)
            {
                cust.CustName = dao.VerifyLogin(cust);
                if (cust.CustName != null)
                {
                    //Session.Add("name", user.FirstName);
                    Session["name"] = cust.CustName;
                    Session["email"] = cust.Email;
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.Status = "Error " + dao.message;

                    return View("Status");
                }

            }
            return View(cust);
        }
        public ActionResult ShowAll()
        {
            List<Customer> cust_list = dao.ShowAll();
            if (cust_list.Count == 0)
            {
                ViewBag.error = dao.message;
            }
            ViewBag.message = cust_list.Count;
            return View(cust_list);

        }



    }

}
    
