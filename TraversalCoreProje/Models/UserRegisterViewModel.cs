using System.ComponentModel.DataAnnotations;

namespace TraversalCoreProje.Models
{
	public class UserRegisterViewModel
	{
		[Required(ErrorMessage ="Lütfen adınızı giriniz")]

        public string Name { get; set; }

		[Required(ErrorMessage = "Lütfen soyadınızı giriniz")]

		public string Surname { get; set; }

		[Required(ErrorMessage = "Lütfen kullanıcı adını giriniz")]

		public string Username { get; set; }

		[Required(ErrorMessage = "Lütfen mail adresini giriniz")]

		public string Mail { get; set; }

		[Required(ErrorMessage = "Lütfen şifreyi giriniz")]

		public string Password { get; set; }

		[Required(ErrorMessage = "Lütfen şifreyi tekrar giriniz")]
		[Compare("Password",ErrorMessage = "şifreler uyumlu değil")]
		public string ConfirmPassword { get; set; }

	}
}
