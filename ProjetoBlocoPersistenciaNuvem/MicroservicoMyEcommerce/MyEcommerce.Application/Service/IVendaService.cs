using MyEcommerce.Application.Dto;

namespace MyEcommerce.Application.Service;

public interface IVendaService
{
    Task<VendaOutputDto> Create(VendaInputDto dto);
    Task<List<VendaOutputDto>> GetAll();
    Task<VendaOutputDto> GetById(Guid id);
    Task<VendaOutputDto> Update(Guid id, VendaInputDto dto);
    Task<bool> Delete(Guid id);

}