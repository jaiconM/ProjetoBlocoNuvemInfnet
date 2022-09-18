using MyEcommerce.Application.Dto;

namespace MyEcommerce.Application.Service;

public interface IProdutoService
{
    Task<ProdutoOutputDto> Create(ProdutoInputDto dto);
    Task<List<ProdutoOutputDto>> GetAll();
    Task<ProdutoOutputDto> GetById(string id);
    Task<ProdutoOutputDto> Update(string id, ProdutoInputDto dto);
    Task<bool> Delete(string id);

}