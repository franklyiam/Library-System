using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mvc;
using HW5.Models;
using HW5.Service;
using HW5.ViewModels;

namespace HW5.Controllers
{
    public class HomeController : Controller
    {
        private readonly iService service;

        public HomeController()
        {
            service = new HW5.Service.Service();
        }


        
        public ActionResult Index()
        {

            return View(service.GetBook());


        }

        public ActionResult Borrow(int studentId, int bookId)
        {

            service.BorrowBook(bookId, studentId);

            return RedirectToAction("Details", new { id = bookId });
        }


        public ActionResult ReturnBook(int bookId)
        {

            service.ReturnBook(bookId);

            return RedirectToAction("Details", new { id = bookId });
        }



        public ActionResult Students(int id)
        {

            return View(service.GetStudent(id));

        }


        [HttpPost]
        public ActionResult Index(string searchstring, int? typeid, int? authorid) {

        


            if (searchstring == "" && typeid == null)
            {

                return View(service.GetBook().Where(b => b.authorId == authorid).ToList());

            }
            else if (searchstring == "" && authorid == null)
            {


                return View(service.GetBook().Where(b => b.typeId == typeid).ToList());

            }
            else if (typeid == null && authorid == null)
            {

                return View(service.GetBook().Where(b => b.name.ToLower().Contains(searchstring.ToLower())).ToList());
            }
            else if (authorid == null && searchstring != "")
            {

                return View(service.GetBook().Where(b => b.name.Contains(searchstring.ToLower()) && b.typeId == typeid).ToList());

            }
            else if (typeid == null && searchstring != "")
            {

                return View(service.GetBook().Where(b => b.name.ToLower().Contains(searchstring.ToLower()) && b.authorId == authorid).ToList());
            }

            else if (searchstring == "")
            {

                return View(service.GetBook().Where(b => b.authorId == authorid && b.typeId == typeid).ToList());

            }
            else
            {

                return View(service.GetBook().Where(b => b.name.Contains(searchstring.ToLower()) && b.authorId == authorid && b.typeId == typeid).ToList());
            }

      
        
        }

       
        public ActionResult Details(int id) {

            return View(service.GetBorrow(id));
        }

        [HttpPost]
        public ActionResult Students(string searchstring,string className, int id)
        {
          

            if (searchstring == "")
            {

                return View(service.GetStudent(id).Where(z => z.@class.Contains(className)).ToList());
            }
            else if (className == "")
            {

                return View(service.GetStudent(id).Where(z => z.name.ToLower().Contains(searchstring.ToLower())).ToList());

            }
            else
            {

                return View(service.GetStudent(id).Where(z => z.name.ToLower().Contains(searchstring.ToLower()) && z.@class.Contains(className)).ToList());
            }

        }

     
    }
}