using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WorkingWithCRUD_Operation.Models;
using System.Data.Entity;
namespace WorkingWithCRUD_Operation.Controllers
{
    public class HomeController : Controller
    {
        ProductDBContext db = new ProductDBContext();

        // GET: Home
        public ActionResult Index(int page=1)
        {
            ViewBag.totalPages =(int)(Math.Ceiling((double)db.Products.Count() / 5));
            ViewBag.currentPage = page;
            return View(db.Products.OrderBy(x => x.ProductId).Skip((page-1)*5).Take(5).ToList());
            //return View(db.Products.ToList());
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Product p)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(p);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Edit(int id)
        {
            var product = db.Products.First(x => x.ProductId == id);
            return View(product); 
        }


        [HttpPost]
        public ActionResult Edit(Product p)
        {
            if (ModelState.IsValid)
            {
                db.Entry(p).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(p);
        }

        public ActionResult Delete(int id)
        {
            var product = db.Products.First(x => x.ProductId == id);
            return View(product);
        }

        [HttpPost]
        [ActionName("Delete")]

        public ActionResult DoDelete(int id)
        {
            var p = new Product() { ProductId = id };
            db.Entry(p).State = EntityState.Deleted;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}