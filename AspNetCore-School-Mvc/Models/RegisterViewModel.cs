using System.ComponentModel.DataAnnotations;

namespace AspNetCore_School_Mvc.Models
{
    public class RegisterViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "İsim Alanı Boş Bırakılamaz")]
        [Display(Name = "İsim")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Soyisim Alanı Boş Bırakılamaz")]
        [Display(Name = "Soyisim")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Kullanıcı Adı Alanı Boş Bırakılamaz")]
        [Display(Name = "Kullanıcı Adı")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Telefon Alanı Boş Bırakılamaz")]
        [Display(Name = "Telefon Numarası")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Email Alanı Boş Bırakılamaz")]
        [EmailAddress(ErrorMessage = "Email Formatı Uygun Değil")]

        public string Email { get; set; }
        [Required(ErrorMessage = "Sifre Boş Bırakılamaz")]
        [Display(Name = "Şifre")]  //ekranda asp-for olan label da yazacak olan isim
        [DataType(DataType.Password)] //girilen karakterleri göstermemesi için
        public string Password { get; set; }
        [Required(ErrorMessage = "Sifre Onay Boş Bırakılamaz")]
        [Compare("Password", ErrorMessage = "Şifreler Uyuşmuyor")]   // password ile karşılaştır
        [Display(Name = "Şifre Tekrar")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

    }
}
