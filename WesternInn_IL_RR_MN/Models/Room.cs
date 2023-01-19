using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WesternInn_IL_RR_MN.Models
{
    public class Room
    {
        public int RoomID { get; set; }

        [Required]
        [RegularExpression(@"[G][1-3]")]
        public string Level { get; set; } = String.Empty;

        [Display(Name = "Bed Count")]
        [RegularExpression(@"[1-3]")]
        public int BedCount { get; set; }

        [Range(50.00, 300.00)]
        public decimal Price { get; set; }

        public ICollection<Booking>? TheBookings { get; set; }
    }
}
