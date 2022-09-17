using Microsoft.EntityFrameworkCore;

namespace MyEcommerce.Data.Contexto;

public class MyEcommerceContext : DbContext
{
    public MyEcommerceContext(DbContextOptions<MyEcommerceContext> options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => base.OnConfiguring(optionsBuilder);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(MyEcommerceContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}