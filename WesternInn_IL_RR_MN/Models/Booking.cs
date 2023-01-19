using System.ComponentModel.DataAnnotations;

namespace WesternInn_IL_RR_MN.Models
{
    public class Booking
    {
        public int Id { get; set; }

        [Display(Name = "Room ID")]
        public int RoomID { get; set; }

        [Display(Name = "Guest's Email")]
        [DataType(DataType.EmailAddress)]
        public string GuestEmail { get; set; } = String.Empty;

        [Display(Name = "Check In")]
        [DataType(DataType.Date)]
        public DateTime CheckIn { get; set; }

        [Display(Name = "Check Out")]
        [DataType(DataType.Date)]
        public DateTime CheckOut { get; set; }

        [Range(0.00, 10000.00)]
        public decimal Cost { get; set; }

        public Room? TheRoom { get; set; }

        public Guest? TheGuest { get; set; }
    }
}
