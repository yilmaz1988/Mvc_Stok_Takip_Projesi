using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BonusMvcStok.Models.Entity;
using BonusMvcStok.ViewModels;

namespace BonusMvcStok.Controllers
{
    [Authorize(Roles = "A")]
    public class PersonelController : Controller
    {
        // GET: Personel
        DbMvcStokEntities db = new DbMvcStokEntities();
        public ActionResult Index()
        {
            var model = db.tblpersonel.Include(x => x.tbldepartman).ToList();
            return View(model);
        }
        public ActionResult YeniPersonelEkle()
        {
            var model = new PersonelFormViewModel()
            {
                Departmanlar = db.tbldepartman.ToList()
            };
            return View("YeniPersonelEkle", model);
        }
        [HttpPost]
        public ActionResult Kaydet(tblpersonel personel)
        {
            if (personel.id == 0)//ekleme işlemi
            {
                db.tblpersonel.Add(personel);
            }
            else//güncelleme işlemi
            {
                db.Entry(personel).State = System.Data.Entity.EntityState.Modified;
            }
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult PersonelSil(int id)
        {
            var personel = db.tblpersonel.Find(id);
            db.tblpersonel.Remove(personel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult PersonelGuncelle(int id)
        {
            var model = new PersonelFormViewModel()
            {
                Departmanlar = db.tbldepartman.ToList(),
                Personel = db.tblpersonel.Find(id)
            };
            return View("YeniPersonelEkle", model);

        }
    }
}