using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.Models
{
    public class Room
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Room number is Required"), Display(Name = "Room Number")]
        public int RoomNumber { get; set; }
        //[Required(ErrorMessage = "Whiteboard availability is required"), Column(TypeName = "varchar(5)"), Display(Name = "Has A Whiteboard?")]
        public bool Whiteboard { get; set; }
        //[Required(ErrorMessage = "Monitor availability is required"), Column(TypeName = "varchar(5)"), Display(Name = "Has A Monitor?")]
        public bool Monitor { get; set; }
        [Required(ErrorMessage = "Room Max Occupancy is Required"), Display(Name = "Max Occupancy")]
        public int MaxOccupancy { get; set; }

        public ICollection<Reservation> Reservations { get; set; }
    }
}
