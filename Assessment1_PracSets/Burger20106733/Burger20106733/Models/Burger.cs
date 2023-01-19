using System.ComponentModel.DataAnnotations;

namespace Burger20106733.Models
{
    public class Burger
    {
        public int burgerID { get; set; }
        [Display(Name="Burger Name")]
        [Required]
        [RegularExpression(@"[^a-zA-Z0-9_\s]", ErrorMessage="Letters, digits, underscore and space contained only.")]
        [StringLength(15, MinimumLength=5)]
        public string BurgerName { get; set; } = string.Empty;
        [Display(Name="Price Each")]
        [DataType(DataType.Currency)]
        [Range(10.00, 20.00)]
        public double Price { get; set; }
    }
}
