using Dukan.Models.Master;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dukan.Models.Bill;

public class ShopCusBill
{
    [Key]
    public int SopCusBId { get; set; }

    [ValidateNever]
    [Display(Name = "Shop Detail")]
    public ShopDetail ShopDetails { get; set; }

    [ForeignKey(nameof(ShopDetails))]
    [Display(Name = "Business Name ")]
    [Required(ErrorMessage = "Business Name  is required.")]
    public int? SpDetId { get; set; }

    [ValidateNever]
    [Display(Name = "Shop Customer")]
    public ShopCustomer ShopCustomers { get; set; }

    [ForeignKey(nameof(ShopCustomers))]
    [Display(Name = "Shop Customer")]
    [Required(ErrorMessage = "Shop Customer  is required.")]
    public int? SCusId { get; set; }

    [ValidateNever]
    [Display(Name = "Product")]
    public Product Products { get; set; }

    [ForeignKey(nameof(Products))]
    [Display(Name = "Product ")]
    [Required(ErrorMessage = "Product is required.")]
    public int? ProId { get; set; }

    [Display(Name = "Quantity")]
    [Required(ErrorMessage = "Quantity is required.")]
    public int Quantity { get; set; }

    [Display(Name = "Amount")]
    [Required(ErrorMessage = "Amount is required.")]
    public decimal Amount { get; set; }
    public decimal Percentage { get; set; }
}
