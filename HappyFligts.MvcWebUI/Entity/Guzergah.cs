using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HappyFligts.MvcWebUI.Entity
{
	public class Guzergah
	{
		public int Id { get; set; }
		public string Guzergah_Nereden { get; set; }
		public string Guzergah_Nereye { get; set; }

		public List<Ucretler> UcretList { get; set; }

		public List<Ucuslar> UcusList { get; set; }
	}
}