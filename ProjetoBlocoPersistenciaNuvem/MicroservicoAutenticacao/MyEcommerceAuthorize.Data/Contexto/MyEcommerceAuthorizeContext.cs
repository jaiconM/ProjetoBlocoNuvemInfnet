using Microsoft.EntityFrameworkCore;

namespace MyEcommerceAuthorize.Data.Contexto;

public class MyEcommerceAuthorizeContext : DbContext
{
    public MyEcommerceAuthorizeContext(DbContextOptions<MyEcommerceAuthorizeContext> options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => base.OnConfiguring(optionsBuilder);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(MyEcommerceAuthorizeContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}