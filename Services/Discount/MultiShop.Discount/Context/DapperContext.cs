using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MultiShop.Discount.Entities;

namespace MultiShop.Discount.Context;

public class DapperContext(IConfiguration configuration) : DbContext
{
    private readonly string? _connectionString = configuration.GetConnectionString("DefaultConnection");

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=MFBILGIN;Initial Catalog=MultiShopDiscountDatabase;Integrated Security=true;TrustServerCertificate=True");
    }

    public DbSet<Coupon> Coupons { get; set; }
    public IDbConnection CreateConnection()=> new SqlConnection(_connectionString);
}