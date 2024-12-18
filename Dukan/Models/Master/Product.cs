using System.ComponentModel.DataAnnotations;

namespace Dukan.Models.Master;

public class Product
{
    [Key]
    public int ProId { get; set; }
    [Required(ErrorMessage = "Product Name is required.")]
    [Display(Name = "Product Name")]
    public string? ProName { get; set; }

    [Required(ErrorMessage = "Brand is required.")]
    [Display(Name = "Brand Name")]
    public string? Brand { get; set; }

    [Required(ErrorMessage = "MRP is required.")]
    [Range(1, int.MaxValue, ErrorMessage = "MRP must be greater than 0.")]
    [Display(Name = "Maximum Retail Price (MRP)")]
    public int Mrp { get; set; }

    [Required(ErrorMessage = "Quantity is required.")]
    [Range(1, int.MaxValue, ErrorMessage = "Quantity must be greater than 0.")]
    [Display(Name = "Quantity")]
    public int NoQuantity { get; set; }
}

