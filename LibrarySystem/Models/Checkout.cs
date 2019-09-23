using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LibrarySystem.Models
{
    public class Checkout
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CheckoutID { get; set; }
        public int MemberID { get; set; }
        public int BookID { get; set; }
        [DataType(DataType.Date)]
        public DateTime CheckoutDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime? ReturnDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime? DateReturned { get; set; }

        [ForeignKey("MemberID")]
        public virtual Member Members { get; set; }
        [ForeignKey("BookID")]
        public virtual Book Books { get; set; }

    }
}
