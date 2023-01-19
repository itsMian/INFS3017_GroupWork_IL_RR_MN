using System.ComponentModel.DataAnnotations;

namespace Burger20106733.Models
{
    public class BurgerOrder
    {
        public int OrderID { get; set; }
        [Required]
        [Display(Name = "Burger Name")]
        public string BurgerName { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Number of Burgers")]
        [Range(1, 10, ErrorMessage = "The number of burgers must be between 1 and 10")]
        public int BurgerCount { get; set; }

        [Required]
        [Display(Name = "Credit Card Number")]
        [StringLength(16, MinimumLength = 16, ErrorMessage="Credit card number must be 16 digits.")]
        public string CreditCard { get; set; } = string.Empty;
    }
}
