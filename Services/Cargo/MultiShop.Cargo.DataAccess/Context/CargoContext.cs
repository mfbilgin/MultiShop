using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MultiShop.Cargo.Entities.Concrete;

namespace MultiShop.Cargo.DataAccess.Context;

public class CargoContext(IConfiguration configuration) : DbContext
{
    private readonly string? _connectionString = configuration.GetConnectionString("DefaultConnection");
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //optionsBuilder.UseSqlServer("Server=localhost,1441;Initial Catalog=MultiShopCargoDatabase;TrustServerCertificate=True;User=sa;Password=123456Mm*");
        optionsBuilder.UseSqlServer(_connectionString);
    }

    public DbSet<CargoCompany> CargoCompanies { get; set; }
    public DbSet<CargoDetail> CargoDetails { get; set; }
    public DbSet<CargoCustomer> CargoCustomers { get; set; }
    public DbSet<CargoOperation> CargoOperations { get; set; }
}