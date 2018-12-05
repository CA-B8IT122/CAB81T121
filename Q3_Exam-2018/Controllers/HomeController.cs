using Q3_Exam_2018.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Q3_Exam_2018.Controllers
{
    public class HomeController : Controller
    {
        DAO dao = new DAO();

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
       
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(Member member)
        {
            int counter = 0;
            counter = dao.InsertMember(member);
            if (counter == 1)
            {
                Response.Write("Success");
                    }
            else
            {
                Response.Write("Error" + dao.message);
            }
            return View();

        }
  
        public ActionResult ShowAll()
        {

           
            List<Member> mem_list = dao.ShowAllMembers();
            if (mem_list.Count == 0)
            {
                ViewBag.error = dao.message;
            }
            ViewBag.message = mem_list.Count;
            return View(mem_list);



        }
    }
}