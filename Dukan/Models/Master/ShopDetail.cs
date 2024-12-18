using System.ComponentModel.DataAnnotations;

namespace Dukan.Models.Master;

public class ShopDetail
{
    [Key]
    public int SpDetId { get; set; }
    [Display(Name = "Shop Owner Name")]
    [Required(ErrorMessage = "Shop Owner Name is required.")]
    public string? ShopOwnerName { get; set; }

    [Display(Name = "Shop Name")]
    [Required(ErrorMessage = "Shop Name is required.")]
    public string? ShopName { get; set; }

    [Display(Name = "Shop Number")]
    [Required(ErrorMessage = "Shop Number is required.")]
    [Phone(ErrorMessage = "Please enter a valid phone number.")]
    public string? ShopNumber { get; set; }

    [Display(Name = "Alternate Mobile Number")]
    public string? AlternateMobileNumber { get; set; }

    [Display(Name = "Shop Address")]
    [Required(ErrorMessage = "Shop Address is required.")]
    public string? ShopAddress { get; set; }

    [Display(Name = "Shop GST Number")]
    public string? ShopGSTNo { get; set; }
}

