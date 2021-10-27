using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BonusMvcStok.Models.Entity;
using System.Web.Security;


namespace BonusMvcStok.Controllers
{
    [AllowAnonymous]
    public class GirisYapController : Controller
    {

        DbMvcStokEntities db = new DbMvcStokEntities();
        // GET: GirisYap
        public ActionResult Giris()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Giris(tbladmin t)
        {

            var bilgiler = db.tbladmin.FirstOrDefault(x => x.kullanici == t.kullanici && x.sifre == t.sifre);
            if (bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.kullanici, bilgiler.BeniHatirla);
                return RedirectToAction("Index", "Musteri");
            }
            else
            {
               
                return View();
            }

        }

        public ActionResult Index()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Giris", "GirisYap");

        }

    }
}