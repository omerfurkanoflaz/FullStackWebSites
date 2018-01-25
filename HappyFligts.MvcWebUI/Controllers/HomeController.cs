using HappyFligts.MvcWebUI.Entity;
using HappyFligts.MvcWebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HappyFligts.MvcWebUI.Controllers
{
	public class HomeController : Controller
	{

		DataContext _context = new DataContext();
		//Index sayfasındaki bilet sorgulama formunda nereden ve nereye elemanlarını tek tek doldurmak yerine Havalimanı tablosuyla doldurmak için PartialView oluşturdum.
		public PartialViewResult HavalimaniListesi() 
		{
			return PartialView(_context.Airport.ToList());//Havalimanı tablosundaki satırları listeyip getir.
		}


		// GET: Home
		public ActionResult Index()
		{
			return View();
		}
		public ActionResult About()
		{
			return View();
		}
		public ActionResult Blog()
		{
			return View();
		}
		public ActionResult BlogVenice()
		{
			return View();
		}
		public ActionResult BlogBerlin()
		{
			return View();
		}
		public ActionResult BlogIstanbul()
		{
			return View();
		}
		public ActionResult BlogChicago()
		{
			return View();
		}
		public ActionResult Contact()
		{
			return View();
		}
		static DateTime degisken = default(DateTime);
		static string degisken2 = "", degisken3 = "",yetiskin="";
		static int idDegeri = default(int);
		[HttpPost]
		public ActionResult OnlineTicket(DateTime ucusTarihi, string nereden, string nereye, FormCollection frm, DateTime? donusTarihi)
		{
			//form üzerindeki değerleri onlineticket üzerinden alıp farklı actionların ulaşabilmesi için değişkene atıyorum.
			degisken = Convert.ToDateTime(frm["donusTarihi"]); 
			degisken2 = frm["nereden"].ToString();
			degisken3 = frm["nereye"].ToString();
			ViewBag.yolculukTipi = frm["optradio"].ToString();//formdaki radio butonlardan seçili olanın değerini alıyorum.
			TempData["yetiskinSayisi"] = frm["yetiskin"].ToString(); //formdaki yetişkin sayısını belirten elemanda seçilen değeri TempData ile aldım.
			TempData["cocukSayisi"] = frm["cocuk"].ToString();
			if (nereden == nereye)
			{//Eğer varış yeri kalkış yeri ile aynı ise alert kutusu gösteriyorum.
				Response.Write("<script language='javascript'>alert('Kalkış yeri ve varış yeri aynı olamaz.');</script>");
			}
			//Linq sorgusu: Uçuşlar tablosunda parametre olarak gelen uçuş tarihi nereden ve nereye değerlerine eşit olan biletleri listele ve getir.
			return View(_context.Flights.Where(i => i.UcusTarihi == ucusTarihi && i.Guzergah.Guzergah_Nereden == nereden && i.Guzergah.Guzergah_Nereye == nereye).ToList());
			
		}
		public ActionResult Donus(int id) //OnlineTicket ile seçilen bilet id'sini parametre olarak aldım.
		{
			idDegeri = id;
			return View(_context.Flights.Where(i => i.Guzergah.Guzergah_Nereden == degisken3 && i.Guzergah.Guzergah_Nereye == degisken2 && i.UcusTarihi ==degisken).ToList());
		}

		public ActionResult Payment(int? donusid,int? id)
		{
			return View(_context.Flights.Where(i => i.Id == idDegeri || i.Id == donusid || i.Id == id).ToList());
		}

	}
}