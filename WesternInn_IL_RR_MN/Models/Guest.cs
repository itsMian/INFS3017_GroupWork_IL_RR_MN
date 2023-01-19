using MessagePack;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using KeyAttribute = System.ComponentModel.DataAnnotations.KeyAttribute;

namespace WesternInn_IL_RR_MN.Models
{
    public class Guest
    {
        [Key, Required]
        [Display(Name = "Email Address")]
        [DataType(DataType.EmailAddress)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Email { get; set; } = String.Empty;

        [Required]
        [StringLength(20, MinimumLength=2)]
        [RegularExpression(@"a-zA-Z'-")]
        public string Surname { get; set; } = String.Empty;

        [Required]
        [Display(Name = "Given Name")]
        [StringLength(20, MinimumLength = 2)]
        [RegularExpression(@"a-zA-Z'-")]
        public string GivenName { get; set; } = String.Empty;

        [Required]
        [RegularExpression(@"[0-9]{4}")]
        public string Postcode { get; set; } = String.Empty;

        public ICollection<Booking>? TheBookings { get; set; }
    }
}
