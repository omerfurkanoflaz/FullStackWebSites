using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HappyFligts.MvcWebUI.Entity
{
	public class Ucretler
	{
		public int Id { get; set; }
		public double Yetiskin { get; set; }
		public double Cocuk { get; set; }


		public int GuzerhahId { get; set; }
		public virtual Guzergah Guzergah { get; set; }

		public List<Ucuslar> UcusList { get; set; }
		
	}
	
}