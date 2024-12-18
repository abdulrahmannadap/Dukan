using System.ComponentModel.DataAnnotations;

namespace Dukan.Models.Master;

public class ShopCustomer
{
    [Key]
    public int SCusId { get; set; }
    [Required(ErrorMessage = "Customer name is required.")]
    [Display(Name = "Customer Name")]
    public string? ScusName { get; set; }

    [Required(ErrorMessage = "Customer address is required.")]
    [Display(Name = "Customer Address")]
    public string? ScusAdd { get; set; }

    [Required(ErrorMessage = "Shop name is required.")]
    [Display(Name = "Shop Name")]
    public string? ScusShopName { get; set; }

    [Required(ErrorMessage = "Join date is required.")]
    [Display(Name = "Join Date")]
    public DateTime JoindDate { get; set; } = DateTime.UtcNow;// Default to current UTC date and time

    [Required(ErrorMessage = "Mobile number is required.")]
    [Display(Name = "Mobile Number")]
    public string? ScusMobileNo { get; set; }

    //[Required(ErrorMessage = "Aadhar number is required.")]
    [Display(Name = "Aadhar Number")]
    public string? ScusAddharNo { get; set; }

    //[Required(ErrorMessage = "GST number is required.")]
    [Display(Name = "GST Number")]
    public string? ScusGSTNo { get; set; }

}

