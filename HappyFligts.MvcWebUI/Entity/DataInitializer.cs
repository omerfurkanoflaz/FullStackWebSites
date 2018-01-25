using HappyFligts.MvcWebUI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HappyFligts.MvcWebUI.Entity
{
	//Bu sınıfı veritabanına test verileri eklemek için oluşturdum.
	public class DataInitializer:DropCreateDatabaseIfModelChanges<DataContext> //Model değiştiyse DataContext'in gösterdiği veri tabanını tekrar oluştur.
	{
		protected override void Seed(DataContext context)
		{
			List<Guzergah> guzergahlar = new List<Guzergah>()
			{
				new Guzergah(){ Guzergah_Nereden="Istanbul Atatürk Havalimanı",Guzergah_Nereye="İzmir Adnan Menderes Havalimanı"},
				new Guzergah(){ Guzergah_Nereden="Istanbul Atatürk Havalimanı",Guzergah_Nereye="Los Angeles Internatinoal Airport" },
				new Guzergah(){ Guzergah_Nereden="Istanbul Atatürk Havalimanı",Guzergah_Nereye="Paris Charles De Gaulle International Airport" },
				new Guzergah(){ Guzergah_Nereden="Istanbul Atatürk Havalimanı",Guzergah_Nereye="Sivas Nuri Demirağ Havalimanı" },
				new Guzergah(){ Guzergah_Nereden="Istanbul Atatürk Havalimanı",Guzergah_Nereye="İzmir Adnan Menderes Havalimanı" },
				new Guzergah(){ Guzergah_Nereden="Istanbul Atatürk Havalimanı",Guzergah_Nereye="İzmir Adnan Menderes Havalimanı" },
				new Guzergah(){ Guzergah_Nereden="Istanbul Atatürk Havalimanı",Guzergah_Nereye="Ankara Esenboğa Havalimanı" },
				new Guzergah(){ Guzergah_Nereden="Istanbul Sabiha Gökçen Havalimanı",Guzergah_Nereye="Adana Şakir Paşa Havalimanı" },
				new Guzergah(){ Guzergah_Nereden="İzmir Adnan Menderes Havalimanı",Guzergah_Nereye="Erzurum Havalimanı" },
				new Guzergah(){ Guzergah_Nereden="Sivas Nuri Demirağ Havalimanı",Guzergah_Nereye="Isparta Süleyman Demirel Havalimanı" },
				new Guzergah(){ Guzergah_Nereden="İzmir Adnan Menderes Havalimanı",Guzergah_Nereye="Istanbul Atatürk Havalimanı" }
			};
			foreach(var guzergah in guzergahlar)
			{
				context.Route.Add(guzergah); //DataContextte oluşturduğum listelere test verilerini ekliyorum.
			}
			context.SaveChanges();

			List<Ucretler> ucretler = new List<Ucretler>()
			{
				new Ucretler(){ GuzerhahId=1, Yetiskin=129.99, Cocuk=69.99},
				new Ucretler(){ GuzerhahId=2, Yetiskin=329.99, Cocuk=159.99},
				new Ucretler(){ GuzerhahId=3, Yetiskin=289.99, Cocuk=189.99},
				new Ucretler(){ GuzerhahId=4, Yetiskin=129.99, Cocuk=69.99},
				new Ucretler(){ GuzerhahId=5, Yetiskin=159.99, Cocuk=89.99},
				new Ucretler(){ GuzerhahId=6, Yetiskin=129.99, Cocuk=69.99},
				new Ucretler(){ GuzerhahId=7, Yetiskin=239.99,Cocuk=159.99},
				new Ucretler(){ GuzerhahId=8,Yetiskin=289.99, Cocuk=189.99},
				new Ucretler(){ GuzerhahId=9, Yetiskin=129.99, Cocuk=69.99},
				new Ucretler(){ GuzerhahId=10, Yetiskin=159.99, Cocuk=89.99}

			};
			foreach(var ucret in ucretler)
			{
				context.Charges.Add(ucret);
			}
			context.SaveChanges();

			List<Ucuslar> ucuslar = new List<Ucuslar>()
			{
				new Ucuslar(){ UcusTarihi=Convert.ToDateTime("02.02.2018"),KalkisSaati="12:35",VarisSaati="13:55", UcretlerId=1,GuzergahId=1},
				new Ucuslar(){ UcusTarihi=Convert.ToDateTime("02.02.2018"), KalkisSaati="08:30",VarisSaati="12:35", UcretlerId=2,GuzergahId=1},
				new Ucuslar(){UcusTarihi=Convert.ToDateTime("02.02.2018"), KalkisSaati="20:50",VarisSaati="22:15", UcretlerId=3,GuzergahId=1},
				new Ucuslar(){UcusTarihi=Convert.ToDateTime("04.02.2018") , KalkisSaati="14:35",VarisSaati="16:55", UcretlerId=4,GuzergahId=4},
				new Ucuslar(){ UcusTarihi=Convert.ToDateTime("05.02.2018"), KalkisSaati="06:55",VarisSaati="09:35", UcretlerId=5,GuzergahId=5},
				new Ucuslar(){UcusTarihi=Convert.ToDateTime("06.02.2018"), KalkisSaati="18:35",VarisSaati="20:15", UcretlerId=6,GuzergahId=6},
				new Ucuslar(){ UcusTarihi=Convert.ToDateTime("06.02.2018"), KalkisSaati="19:15",VarisSaati="21:45", UcretlerId=7,GuzergahId=7},
				new Ucuslar(){ UcusTarihi=Convert.ToDateTime("06.02.2018"), KalkisSaati="12:35",VarisSaati="13:55", UcretlerId=8,GuzergahId=8},
				new Ucuslar(){ UcusTarihi=Convert.ToDateTime("07.02.2018"), KalkisSaati="12:35",VarisSaati="13:55", UcretlerId=9,GuzergahId=11},
				new Ucuslar(){ UcusTarihi=Convert.ToDateTime("08.02.2018"), KalkisSaati="16:45",VarisSaati="18:55", UcretlerId=10,GuzergahId=10}

			};
			foreach (var ucus in ucuslar)
			{
				context.Flights.Add(ucus);
			}
			context.SaveChanges();
			List<Havalimanı> havalimanları = new List<Havalimanı>()
			{
				new Havalimanı(){ Havalimani_Adi="Adana Şakir Paşa Havalimanı"},
				new Havalimanı(){ Havalimani_Adi="Ankara Esenboğa Havalimanı"},
				new Havalimanı(){ Havalimani_Adi="Amsterdam Schiphol Intarnational Airport"},
				new Havalimanı(){ Havalimani_Adi="Antalya Havalimanı"},
				new Havalimanı(){Havalimani_Adi="Bursa Yenişehir Havalimanı"},
				new Havalimanı(){Havalimani_Adi="Chicago O'Hare Uluslararası Havaalanı"},
				new Havalimanı(){Havalimani_Adi="Erzincan Havalimanı"},
				new Havalimanı(){Havalimani_Adi="Erzurum Havalimanı"},
				new Havalimanı(){Havalimani_Adi="Eskişehir Anadolu Havalimanı"},
				new Havalimanı(){Havalimani_Adi="Isparta Süleyman Demirel Havalimanı"},
				new Havalimanı(){Havalimani_Adi="Istanbul Atatürk Havalimanı"},
				new Havalimanı(){Havalimani_Adi="Istanbul Sabiha Gökçen Havalimanı"},
				new Havalimanı(){Havalimani_Adi="İzmir Adnan Menderes Havalimanı"},
				new Havalimanı(){Havalimani_Adi="Kayseri Erkilet Havalimanı"},
				new Havalimanı(){Havalimani_Adi="Konya Havalimanı"},
				new Havalimanı(){ Havalimani_Adi="Londra Gatwick Internatinoal Airport"},
				new Havalimanı(){Havalimani_Adi="Los Angeles Internatinoal Airport"},
				new Havalimanı(){Havalimani_Adi="Muğla Milas– Bodrum Havalimanı"},
				new Havalimanı(){ Havalimani_Adi="Munih Franz Josef Strauss International Airport"},
				new Havalimanı(){Havalimani_Adi="New York John F Kennedy International Airport"},
				new Havalimanı(){ Havalimani_Adi="San Francisco International Airport"},
				new Havalimanı(){ Havalimani_Adi="Sivas Nuri Demirağ Havalimanı"},
				new Havalimanı(){Havalimani_Adi="Paris Charles De Gaulle International Airport"},
				new Havalimanı(){ Havalimani_Adi="Venedik Marco Polo International Airport"}
				
			};
			foreach (var havaliman in havalimanları)
			{
				context.Airport.Add(havaliman);
			}
			context.SaveChanges();
			base.Seed(context);
		}

	}
}