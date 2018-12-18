using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using CA_B8IT121.Models;

namespace CA_B8IT121.Controllers
{
    public class CustomerController : Controller
    {
        DAO dao = new DAO();

        // GET: Customer
        //public ActionResult Index()
        //{
        //    return View();
        //}
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
                Response.Write("Error in customer controller " + dao.message);
            }
            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Customer c1)
        {


            ModelState.Remove("Name");
            ModelState.Remove("StreetAddress");
            ModelState.Remove("City");
            ModelState.Remove("ConfirmPassword");
            ModelState.Remove("Phone");
            ModelState.Remove("Gender");
            ModelState.Remove("MailList");
            ModelState.Remove("CustType");

            Customer c2 = null;
            

            if (ModelState.IsValid)
            {
                c2 = dao.VerifyLogin(c1.Email);

                if (c2.CustType == "Administrator")
                {
                    return RedirectToAction("Index", "Admin");
                }
                else if (c2.CustType == "Customer")
                {
                    c2 = dao.VerifyLogin(c1.Email);
                    if (c2.Name != null)
                    {
                        //Session["Name"] = c1.Name;
                        //Session["Email"] = c1.Email;

                        return RedirectToAction("Index", "Home");
                    }
                }

                else
                {
                    ViewBag.Status = "Error " + dao.message;

                    return View("Status");
                }

            }
            else
            {
                Response.Write("not working");
            }
                      
            return View();

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


