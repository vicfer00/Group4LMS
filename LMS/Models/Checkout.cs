using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.Models
{
    public class Checkout
    {
        public int ID { get; set; }
        [Required, Display(Name = "Book")]
        [ForeignKey("Book")]
        public int BookID { get; set; }
        public Book Book { get; set; }
        [Required, Display(Name = "Patron")]
        public int PatronID { get; set; }
        public Patron Patron { get; set; }
        [DataType(DataType.Date),Display(Name ="Borrow Date")]
        public DateTime BorrowDate { get; set; }
        [DataType(DataType.Date), Display(Name = "Return Date")]
        public DateTime ReturnDate { get; set; }
        [DataType(DataType.Date), Display(Name = "Date Returned")]
        public DateTime? DateReturned { get; set; }

    }
}
