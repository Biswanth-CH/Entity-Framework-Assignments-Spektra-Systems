using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Product_Inventory.Models
{
    public class product
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        [Precision(18, 2)]
        public decimal price { get; set; }
        [Required]
        public string category { get; set; }
        [Required]

        public int quantity { get; set; }
    }
}


