using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HappyFligts.MvcWebUI.Entity
{
	public class DataContext:DbContext
	{

		public DataContext(): base("dataConnection") //constructor oluşturuldu. base yapmasaydık varsayılan konuma varsayılan isimde bir veritabanı oluşturulurdu.
		{
			Database.SetInitializer(new DataInitializer()); //DataInitializer'i DataContext içerisinde aktif ettim.
		}
		//Veritabanında bulunmasını istediğim tabloların tipinde listeler oluşturdum. 
		//DbSet:Context sınıfına özgü bir liste tipi
		public DbSet<Guzergah> Route { get; set; }
		public DbSet<Ucretler> Charges { get; set; }
		public DbSet<Yolcular> Passengers { get; set; }
		public DbSet<Ucuslar> Flights { get; set; }
		public DbSet<Havalimanı> Airport { get; set; }

	}
}