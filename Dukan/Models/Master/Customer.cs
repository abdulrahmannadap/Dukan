using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace Dukan.Models.Master;

public class Customer
{
    [Key]
    public int CusId { get; set; }
    [Required(ErrorMessage = "Customer Name is required.")]
    [Display(Name = "Customer Name")]
    public string? CusName { get; set; }

    [Required(ErrorMessage = "Contact Number is required.")]
    [Display(Name = "Contact Number")]
    public string? CusNumber { get; set; }

    [Display(Name = "Address")]
    public string? CusAddress { get; set; }

    [Required(ErrorMessage = "Vehicle Number is required.")]
    [Display(Name = "Vehicle Number")]
    public string? CusVehicleNo { get; set; }

    [Display(Name = "Aadhar Number")]
    public string? CusAadharNo { get; set; }

}

