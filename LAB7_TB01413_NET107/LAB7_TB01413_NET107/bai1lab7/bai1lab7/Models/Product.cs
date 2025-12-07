using System;
using System.ComponentModel.DataAnnotations;

namespace InventoryManagement.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required, StringLength(200)]
        public string Name { get; set; }

        [Required, StringLength(100)]
        public string Category { get; set; }

        [StringLength(50)]
        public string Color { get; set; }

        [Display(Name = "Unit Price")]
        [Range(0, double.MaxValue)]
        public decimal UnitPrice { get; set; }

        [Display(Name = "Available Quantity")]
        [Range(0, int.MaxValue)]
        public int AvailableQuantity { get; set; }

        [Display(Name = "Created Date")]
        public DateTime CreatedDate { get; set; }
    }
}
