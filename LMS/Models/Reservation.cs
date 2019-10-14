using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.Models
{
    public class Reservation
    {
        public int ID { get; set; }
        [Required, Display(Name = "Room")]
        public int RoomID { get; set; }
        public Room Room { get; set; }
        [Required, Display(Name = "Patron")]
        public int PatronID { get; set; }
        public Patron Patron { get; set; }
        [DataType(DataType.Date),Display(Name ="Date")]
        public DateTime ReservationDate { get; set; }
        [DataType(DataType.Time),Display(Name ="Start Time")]
        public DateTime ReservationTime { get; set; }
        [Required]
        public int Duration { get; set; }
        [DataType(DataType.Date)]
        public DateTime? ReservationEndDate { get; set; }
        [DataType(DataType.Time),Display(Name ="End Time")]
        public DateTime? ReservationEndTime { get; set; }
    }
}
