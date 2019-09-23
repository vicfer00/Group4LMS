using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LibrarySystem.Models
{
    public class Book
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int BookID { get; set; }
        [Required(ErrorMessage ="Book ISBN is required"), Column(TypeName = "varchar(20)"), StringLength(20,ErrorMessage ="ISBN is limited to 20 with a minimum of 11",MinimumLength =11)]
        public string ISBN { get; set; }
        [Required(ErrorMessage ="Book title is required"), Column(TypeName = "varchar(50)"), StringLength(50,ErrorMessage ="Title is limited to 50")]
        public string Title { get; set; }
        [Required(ErrorMessage ="Book author is required"), RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$"), Column(TypeName ="varchar(50)"),StringLength(50,ErrorMessage ="Author is limited to 50")]
        public string Author { get; set; }
        [Column(TypeName = "varchar(50)"),StringLength(50,ErrorMessage ="Publisher is limited to 50"),]
        public string Publisher { get; set; }
        [DataType(DataType.Date),Column(TypeName ="Datetime"),Display(Name ="Publish Date")]
        public DateTime? PublishDate { get; set; }
        [Column(TypeName = "varchar(50)"), RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$"), StringLength(50, ErrorMessage = "Genre is limited to 50"),]
        public string Genre { get; set; }
        [Required(ErrorMessage ="Price of book is required"),Column(TypeName ="money"),]
        public decimal Price { get; set; }
        [Required(ErrorMessage ="Book status is required"),Column(TypeName ="varchar(5)"),Display(Name ="isAvailable?")]
        public string Available { get; set; }

        public ICollection<Checkout> Checkouts { get; set; }
    }
}
