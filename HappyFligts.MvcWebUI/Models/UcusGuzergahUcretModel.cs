using HappyFligts.MvcWebUI.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HappyFligts.MvcWebUI.Models
{
	public class UcusGuzergahUcretModel
	{
		public List<Ucuslar> Flight { get; set; }
		public List<Guzergah> Routes { get; set; }
		public List<Ucretler> PassengerCharges { get; set; }
		public List<Yolcular> Passengers { get; set; }
	}

}