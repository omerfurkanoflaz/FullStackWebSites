using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HappyFligts.MvcWebUI.Entity
{
	public class Ucuslar
	{
		public int Id { get; set; }
		public DateTime UcusTarihi { get; set; }
		public string KalkisSaati { get; set; }
		public string VarisSaati { get; set; }

		public int GuzergahId { get; set; }
		public virtual Guzergah Guzergah { get; set; }

		public int UcretlerId { get; set; }
		public virtual Ucretler Ucretler { get; set; }

		public List<Yolcular> YolcuList {get;set;}
	}
}