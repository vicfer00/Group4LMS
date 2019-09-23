using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LibrarySystem.Models
{
    public class Member
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MemberID { get; set; }
        [Required(ErrorMessage = "Member first name is required"), RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$"), Column(TypeName = "varchar(50)"), 
            StringLength(50, ErrorMessage = "First name is limited to 50"),Display(Name ="First Name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Member last name is required"), RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$"), Column(TypeName = "varchar(50)"), 
            StringLength(50, ErrorMessage = "Last name is limited to 50"),Display(Name ="Last Name")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Member email is required"), Column(TypeName = "varchar(50)"), StringLength(50, ErrorMessage = "Email is limited to 50")]
        public string Email { get; set; }
        [DataType(DataType.Date), Column(TypeName = "Datetime"), Display(Name = "Date of Birth")]
        public DateTime DOB { get; set; }
        [Required(ErrorMessage = "Members active status is required"), Column(TypeName = "varchar(10)"), StringLength(10, MinimumLength = 6, ErrorMessage = "Active status is limited to 10")]
        public string Active { get; set; }
        [Required(ErrorMessage = "Members password is required"), Column(TypeName = "varchar(50)"), StringLength(50, MinimumLength = 8, ErrorMessage = "Password must be a minimum of 8 characters")]
        public string Password { get; set; }

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
