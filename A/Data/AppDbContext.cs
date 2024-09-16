using A.Data.Entities;

namespace A.Data;
using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{

    public AppDbContext(DbContextOptions<AppDbContext> options  ) : base(options)
    {
        
    }
    
    
    public DbSet<ProductEntity> Products { get; set; }
    
    public DbSet<SellerEntity> Sellers { get; set; }



    // private readonly string _connectionstring = 
    //     "Server=localhost;Database=be124_ef_2;User=root;Password=Egemenantep27!;";
    //
    //
    // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    // {
    //     optionsBuilder.UseMySql(_connectionstring, ServerVersion.AutoDetect(_connectionstring));
    // }
}