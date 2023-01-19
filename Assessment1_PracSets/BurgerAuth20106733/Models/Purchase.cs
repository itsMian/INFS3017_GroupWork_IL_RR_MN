using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BurgerAuth20106733.Models
{
    public class Purchase
    {
        public int Id { get; set; }

        [Display(Name = "Burger ID")]
        public int BurgerId { get; set; }

        [Display(Name = "Customer's Email")]
        [Required]
        [DataType(DataType.EmailAddress)]
        public string CustomerEmail { get; set; } = string.Empty;

        [Display(Name = "Burger Count")]
        [Range(1, 80)]
        public int BurgerCount { get; set; }

        [Display(Name = "Total Cost")]
        [Range(1.00, 1000.00)]
        public decimal TotalCost { get; set; }

        public Burger? TheBurger { get; set; }

        public Customer? TheCustomer { get; set; }
    }
}
