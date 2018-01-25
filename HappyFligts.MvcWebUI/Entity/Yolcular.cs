using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HappyFligts.MvcWebUI.Entity
{
	public class Yolcular
	{

		public int Id { get; set; }

		[Required]
		[DisplayName("Yolcu Adı")]
		public string YolcuAdi { get; set; }

		[Required]
		[DisplayName("Yolcu Soyadı")]
		public string YolcuSoyadi { get; set; }

		[Required]
		[DisplayName("Yolcu Tc Kimlik")]
		[StringLength(maximumLength: 11, ErrorMessage = "TC Kimlik numarası 11 haneden oluşmalıdır.",MinimumLength =11)]
		//TC Kimlik Numarası 11 haneli olmalı,son hane çift rakamlardan oluşmalı,ilk hane 0 olamaz.
		[RegularExpression(@"^[1-9]{1}[0-9]{9}[0,2,4,6,8]{1}$",ErrorMessage ="Geçersiz Tc Kimlik Numarası")]
		public string YolcuTc { get; set; }

		[Required]
		[DisplayName("Eposta Adresi")]
		[RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
						   @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
						   @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$",
						   ErrorMessage = "Email adresi geçersiz")]
		//E-posta için gerekli validation
		[EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi girmediniz.Lütfen kontrol ediniz.")]
		public string Email { get; set; }

		[Required]
		[DisplayName("Cep Telefonu")]
		public string YolcuTel { get; set; }

		public int UcuslarId { get; set; }
		public virtual Ucuslar Ucuslar { get; set; }

	}
}