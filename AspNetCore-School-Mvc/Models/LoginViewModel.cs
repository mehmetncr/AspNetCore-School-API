using System.ComponentModel.DataAnnotations;

namespace AspNetCore_School_Mvc.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Kullanıcı Adı Alanı Boş Bırakılamaz")]
        [Display(Name = "Kullanıcı Adı")]
        public string UserName { get; set; }


        [Required(ErrorMessage = "Sifre Boş Bırakılamaz")]
        [Display(Name = "Şifre")]  
        [DataType(DataType.Password)] 
        public string Password { get; set; }
        public string ReturnUrl { get; set; }
    }
}
