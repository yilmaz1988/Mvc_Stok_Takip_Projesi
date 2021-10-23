using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BonusMvcStok.Models.Entity;

namespace BonusMvcStok.Controllers
{
    public class DepartmanController : Controller
    {
        DbMvcStokEntities db = new DbMvcStokEntities();
        // GET: Departman
        public ActionResult Index()
        {

            var departman = db.tbldepartman.ToList();
            return View(departman);
        }
        public ActionResult DepartmanGetir(int id)
        {
            var departman = db.tbldepartman.Find(id);
            return View(departman);
        }

        public ActionResult DepartmanGuncelle(tbldepartman p)
        {
            var dep = db.tbldepartman.Find(p.id);
            dep.ad = p.ad;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult DepartmanSil(tbldepartman p1)
        {
            var departman = db.tbldepartman.Find(p1.id);
            db.tbldepartman.Remove(departman);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult YeniDepartman()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniDepartman(tbldepartman p)
        {
            if (!ModelState.IsValid)
            {
                return View("YeniDepartman");
            }
            db.tbldepartman.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}