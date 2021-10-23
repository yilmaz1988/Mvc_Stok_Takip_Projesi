using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BonusMvcStok.Models.Entity;

namespace BonusMvcStok.Controllers
{

    public class SatislarController : Controller
    {
        DbMvcStokEntities db = new DbMvcStokEntities();
        // GET: Satislar

        public ActionResult Index()
        {
            var satislar = db.tblsatislar.ToList();
            return View(satislar);
        }
        [HttpGet]
        public ActionResult YeniSatis()
        {
            //üRÜNLER
            #region Ürünler
            List<SelectListItem> urun = (from x in db.tblurunler.ToList()
                                         select new SelectListItem
                                         {
                                             Text = x.ad,
                                             Value = x.id.ToString()
                                         }).ToList();


            ViewBag.drop1 = urun;
            #endregion

            //Personel

            List<SelectListItem> per = (from x in db.tblpersonel.ToList()
                                        select new SelectListItem
                                        {
                                            Text = x.ad + " " + x.soyad,
                                            Value = x.id.ToString()
                                        }).ToList();
            ViewBag.drop2 = per;



            //Müşteriler
            List<SelectListItem> must = (from x in db.tblmusteri.ToList()
                                         select new SelectListItem
                                         {
                                             Text = x.ad + " " + x.soyad,
                                             Value = x.id.ToString()
                                         }).ToList();
            ViewBag.drop3 = must;
            return View();
        }

        [HttpPost]
        public ActionResult YeniSatis(tblsatislar p)
        {
            p.tarih = DateTime.Now;
            db.tblsatislar.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}