namespace MyEcommerce.Domain.Repository;
public interface IProdutoRepository
{
    Task<Produto> Create(Produto produto);
    Task<List<Produto>> GetAll();
    Task<Produto> GetById(string id);
    Task RemoveById(string id);
    Task<Produto> Update(Produto produto);
}