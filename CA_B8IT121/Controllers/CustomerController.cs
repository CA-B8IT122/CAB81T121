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
                Response.Write("Error in customer controller " + dao);
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
            Response.Write("starting Check");

            ModelState.Remove("Name");
            ModelState.Remove("StreetAddress");
            ModelState.Remove("City");
            ModelState.Remove("ConfirmPassword");
            ModelState.Remove("Gender");
            ModelState.Remove("MailList");
            {

                if (cust.UserType == UserEnum.Administrator )
                {
                    cust.Name = dao.VerifyLogin(cust);
                    if (cust.Name != null)
                    {
                        Session["Name"] = cust.Name;
                        Session["Email"] = cust.Email;

                        return RedirectToAction("Index", "Admin");
                    }
                    else
                    {
                        ViewBag.Status = "Error " + dao.message;
                    }
                        return RedirectToAction("View", "Customer");
                }
                else if (cust.UserType == UserEnum.Customer)
                {
                    cust.Name = dao.VerifyLogin(cust);
                    if (cust.Name != null)
                    {
                        Session["Name"] = cust.Name;
                        Session["Email"] = cust.Email;
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ViewBag.Status = "Error " + dao.message;

                        return View("");
                    }

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


