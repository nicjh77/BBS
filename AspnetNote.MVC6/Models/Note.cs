using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspnetNote.MVC6.Models
{
    public class Note
    {
        [Key]
        public int NoteNo { get; set; }

        [Required(ErrorMessage ="Input title")]
        public string NoteTitle { get; set; }

        [Required(ErrorMessage ="input content")]
        public string NoteContents { get; set; }

        [Required]
        public int UserNo { get; set; }

        // JOIN in code first
        // virtual - lazy loading
        [ForeignKey("UserNo")]
        public virtual User User { get; set; }

        // JOIN in db first
        // public User user { get; set; }
    }
}
