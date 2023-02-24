using labtask2efintro.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace labtask2efintro.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Product model)
        {
            var db = new LABTASK2Entities3();
            db.Products.Add(model);
            db.SaveChanges();
            return RedirectToAction("List");
        }
        public ActionResult List()
        {
            var db = new LABTASK2Entities3();
            var students = db.Products.ToList();
            return View(students);
        }
        public ActionResult Details(int id)
        {
            var db = new LABTASK2Entities3();
            var st = (from s in db.Products
                      where s.Id == id
                      select s).SingleOrDefault();
            return View(st);
        }
        [HttpGet]
        public ActionResult Update(int id)
        {
            var db = new LABTASK2Entities3();
            var st = (from s in db.Products
                      where s.Id == id
                      select s).SingleOrDefault();
            return View(st);
        }
        [HttpPost]
        public ActionResult Update(Product model)
        {
            var db = new LABTASK2Entities3();
            var exst = (from s in db.Products
                        where s.Id == model.Id
                        select s).SingleOrDefault();
            db.Entry(exst).CurrentValues.SetValues(model);
            db.SaveChanges();
            return RedirectToAction("List");
        }


        [HttpGet]
        public ActionResult Delete()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var db = new LABTASK2Entities3();
            var st = (from s in db.Products where s.Id == id select s).SingleOrDefault();
            db.Products.Remove(st);
            db.SaveChanges();
            return RedirectToAction("List");
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}