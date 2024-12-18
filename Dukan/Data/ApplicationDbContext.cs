using Dukan.Models.Bill;
using Dukan.Models.Master;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Dukan.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext(options)
{
    public required DbSet<Product> Products { get; set; }
    public required DbSet<Customer> Customers { get; set; }
    public required DbSet<ShopCustomer> ShopCustomers { get; set; }



    public required DbSet<ShopDetail> ShopDetails { get; set; }
    public required DbSet<ShopCusBill> ShopCusBills { get; set; }

}

