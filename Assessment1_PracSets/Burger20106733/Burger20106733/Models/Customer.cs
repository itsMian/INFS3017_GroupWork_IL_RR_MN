using System.ComponentModel.DataAnnotations;

namespace Burger20106733.Models
{
    public class Customer
    {
        public int CustomerID { get; set; }
        [Display(Name="Family Name")]
        [Required]
        [RegularExpression(@"a-zA-Z'-")]
        [StringLength(20, MinimumLength=2)]
        public string FamilyName { get; set; } = string.Empty;
        [Display(Name="Given Name")]
        [Required]
        [RegularExpression(@"a-zA-Z'-")]
        [StringLength(20, MinimumLength = 2)]
        public string GivenName { get; set; } = string.Empty;
        [Display(Name="Birth Date")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
        [Display(Name = "Email Address")]
        [DataType(DataType.EmailAddress)]
        [Required]
        public string EmailAddress { get; set; } = string.Empty;
        [Display(Name="Mobile Number")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^04[0-9]{2}\s[0-9]{3}\s[0-9]{3}$", ErrorMessage="The format for phone number should be 04xx xxx xxx")]
        [Required]
        public string PhoneNumber { get; set; } = string.Empty;
        [Display(Name = "Postal Code")]
        [DataType(DataType.PostalCode)]
        [RegularExpression(@"^[0-8][0-9]{3}$", ErrorMessage = "Postal Code must be 4 digits and the first digit cannot be 9")]
        [Required]
        public string PostalCode { get; set; } = string.Empty;
    }
}
