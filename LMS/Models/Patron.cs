using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.Models
{
    public class Patron
    {
        
        public int ID { get; set; }
        [Required(ErrorMessage = "Patron first name is required"), RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$"), Column(TypeName = "varchar(50)"),
            StringLength(50, ErrorMessage = "First name is limited to 50"), Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Patron last name is required"), RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$"), Column(TypeName = "varchar(50)"),
            StringLength(50, ErrorMessage = "Last name is limited to 50"), Display(Name = "Last Name")]
        public string LastName { get; set; }
        [DataType(DataType.Date), Column(TypeName = "Datetime"), Display(Name = "Date of Birth")]
        public DateTime DOB { get; set; }
        [Phone]
        public string PhoneNumber { get; set; }
        

        public string FullName
        {
            get
            {
                return LastName + ", " + FirstName;
            }
        }

        public ICollection<Checkout> Checkouts { get; set; }
    }
}
