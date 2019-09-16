using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

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
        public char isAvailable { get; set; }
        [DataType(DataType.Date)]
        public DateTime reservedDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime returnDate { get; set; }

    }
}
