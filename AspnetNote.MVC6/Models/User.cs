using System.ComponentModel.DataAnnotations;

namespace AspnetNote.MVC6.Models
{
    public class User
    {
        [Key]
        public int UserNo { get; set; }

        [Required(ErrorMessage ="Enter User Name")]
        public string UserName { get; set; }

        [Required(ErrorMessage ="Enter User ID")]
        public string UserId { get; set; }

        [Required(ErrorMessage ="Enter User Password")]
        public string UserPassword { get; set; }
    }
}
