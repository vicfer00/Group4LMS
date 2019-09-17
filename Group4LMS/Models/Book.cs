using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Group4LMS.Models
{
    public class Book
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN10 { get; set; }
        public string ISBN13 { get; set; }
        public string Genre { get; set; }
        [Display(Name = "Available")]
        public char isAvailable { get; set; }
        [Display(Name = "Reserved Date")]
        [DataType(DataType.Date)]
        public DateTime reservedDate { get; set; }
        [Display(Name = "Return Date")]
        [DataType(DataType.Date)]
        public DateTime returnDate { get; set; }

    }
}
