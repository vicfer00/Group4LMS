using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LibrarySystem.Models
{
    public class Reservation
    {
        public int ReservationID { get; set; }
        public int MemberID { get; set; }
        public int RoomID { get; set; }
        [DataType(DataType.Date)]
        public DateTime ReservationDate { get; set; }
        [DataType(DataType.Time)]
        public DateTime ReservationTime { get; set; }
        public int Duration { get; set; }
        [DataType(DataType.Date)]
        public DateTime ReservationEndDate { get; set; }
        [DataType(DataType.Time)]
        public DateTime ReservationEndTime { get; set; }
        

        [ForeignKey("MemberID")]
        public virtual Member Members { get; set; }
        [ForeignKey("RoomID")]
        public virtual Room Rooms { get; set; }
    }
}
