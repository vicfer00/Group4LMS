using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LibrarySystem.Models
{
    public class Room
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int RoomID { get; set; }
        [Required(ErrorMessage = "Whiteboard availability is required"), Column(TypeName = "varchar(5)"), Display(Name = "Has Whiteboard?")]
        public string Whiteboard { get; set; }
        [Required(ErrorMessage = "Monitor availability is required"), Column(TypeName = "varchar(5)"), Display(Name = "Has Monitor?")]
        public string Monitor { get; set; }
        [Required(ErrorMessage = "Room Occupancy is Required"), Display(Name = "Occupancy?")]
        public int Occupancy { get; set; }
        [Required(ErrorMessage = "Room availability is required"), Column(TypeName = "varchar(5)"), Display(Name = "Available?")]
        public string Available { get; set; }

        public ICollection<Reservation> Reservations { get; set; }
    }
}
