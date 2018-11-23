using System.ComponentModel.DataAnnotations;

namespace AspnetNote.MVC6.ViewModel
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="Input User ID")]
        public string UserId { get; set; }

        [Required(ErrorMessage ="Input Password")]
        public string UserPassword { get; set; }
    }
}
