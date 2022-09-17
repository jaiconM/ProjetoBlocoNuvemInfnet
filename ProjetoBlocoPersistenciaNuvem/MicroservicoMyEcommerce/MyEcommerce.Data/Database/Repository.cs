using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using MyEcommerce.CrossCutting.Interfaces.Data;
using MyEcommerce.Data.Contexto;
using System.Data;
using System.Linq.Expressions;

namespace MyEcommerce.Data.Database;

public class Repository<T> : IRepository<T> where T : class
{
    protected DbSet<T> Query { get; set; }
    protected DbContext Context { get; set; }

    public Repository(MyEcommerceContext context)
    {
        Context = context;
        Query = Context.Set<T>();
    }

    public async Task<IDbContextTransaction> CreatTransaction() => await Context.Database.BeginTransactionAsync();

    public async Task<IDbContextTransaction> CreatTransaction(IsolationLevel isolation) => await Context.Database.BeginTransactionAsync(isolation);

    public async Task Delete(T entity)
    {
        Query.Remove(entity);
        await Context.SaveChangesAsync();
    }

    public async Task<IEnumerable<T?>> FindAllByCriteria(Expression<Func<T, bool>> expression) => await Query.AsNoTrackingWithIdentityResolution()
                          .Where(expression)
                          .ToListAsync();

    public async Task<T?> FindOneByCriteria(Expression<Func<T, bool>> expression) => await Query.AsNoTrackingWithIdentityResolution()
                          .FirstOrDefaultAsync(expression);

    public async Task<T?> Get(object id) => await Query.FindAsync(id);

    public async Task<IEnumerable<T>> GetAll() => await Query.AsNoTrackingWithIdentityResolution()
                          .ToListAsync();

    public async Task Save(T entity)
    {
        await Query.AddAsync(entity);
        await Context.SaveChangesAsync();
    }

    public async Task Update(T entity)
    {
        Query.Update(entity);
        await Context.SaveChangesAsync();
    }
}
