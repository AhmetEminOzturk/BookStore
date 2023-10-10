using System.ComponentModel.DataAnnotations;

namespace BookStore.Mvc.Models
{
    public class UserLoginViewModel
    {
        [Required(ErrorMessage = "Kullanıcı adı boş bırakılamaz")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Şifre Giriniz")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
