using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HappyFligts.MvcWebUI.Entity;

namespace HappyFligts.MvcWebUI.Controllers
{
    public class YolcularController : Controller
    {
        private DataContext db = new DataContext(); //DataContext sınıfında db adında bir nesne türettim.

        // GET: Yolcular
        public ActionResult Index() //Eklenen yolcuları tabloda göstermek ve ödeme işlemini gerçekleştirmek için Index Action oluşturdum.
        {
            var passengers = db.Passengers.Include(y => y.Ucuslar); //Yolcular tablosundaki satırları listeleyip getir.
            return View(passengers.ToList());
        }
		

        // GET: Yolcular/Create
        public ActionResult Create() //Yolcu bilgilerini istediğim view'ı oluşturdum.
        {
            return View();
			
        }
        // POST: Yolcular/Create
        [HttpPost]
        [ValidateAntiForgeryToken] 
        public ActionResult Create([Bind(Include = "Id,YolcuAdi,YolcuSoyadi,YolcuTc,Email,YolcuTel,UcuslarId")] Yolcular yolcular)
        {
            if (ModelState.IsValid) //Formlar istenilen şekilde doldurulduysa
			{ 
				yolcular.UcuslarId = Convert.ToInt32(TempData["ucusId"]); //yolcunun uçuş bilgileri için seçmiş olduğu uçuşun idsini yolcular.UcuslarId'e atadım.
                db.Passengers.Add(yolcular); //Yolcular tablosuna yolcular ile gelen verileri ekledim.
                db.SaveChanges();//Veritabanındaki değişiklikleri kaydettim.
                return RedirectToAction("Index"); //Yolcular/Index sayfasına yönlendirdim.
            }
			return View(yolcular);
        }

        // GET: Yolcular/Edit/
        public ActionResult Edit(int? id) //seçmiş olduğu yolcu bilgisinin id'sini alıyorum.
        {
            if (id == null) //id boş ise hata mesajı
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Yolcular yolcular = db.Passengers.Find(id);
            if (yolcular == null) 
            {
                return HttpNotFound();
            }
            return View(yolcular);
        }
        // POST: Yolcular/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,YolcuAdi,YolcuSoyadi,YolcuTc,Email,YolcuTel")] Yolcular yolcular)//Kullanıcının doldurması gereken alanları belirledim.
        {
            if (ModelState.IsValid) //Doğrulama doğruysa yani tüm bilgiler Yolcular class'ında belirlenen durumlara uygunsa
            {
				yolcular.UcuslarId = Convert.ToInt32(TempData["ucusId"]);
				db.Entry(yolcular).State = EntityState.Modified; //Yapılan değişiklikleri al.
				db.SaveChanges();//Değişiklikleri kaydet.
                return RedirectToAction("Index"); //Index sayfasına dön.
            }
            return View(yolcular);
        }

        // GET: Yolcular/Delete/5
        public ActionResult Delete(int? id) 
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Yolcular yolcular = db.Passengers.Find(id);
            if (yolcular == null)
            {
                return HttpNotFound();
            }
            return View(yolcular);
        }

        // POST: Yolcular/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id) //seçili olan yolcunun id sini parametre olarak aldım.
        {
            Yolcular yolcular = db.Passengers.Find(id); //seçili id e eşit olan satırı veritabanında bul.
            db.Passengers.Remove(yolcular); //bulduğun satırı sil.
            db.SaveChanges();  //değişiklikleri kaydet.
            return RedirectToAction("Index"); //Index sayfasına dön.
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
