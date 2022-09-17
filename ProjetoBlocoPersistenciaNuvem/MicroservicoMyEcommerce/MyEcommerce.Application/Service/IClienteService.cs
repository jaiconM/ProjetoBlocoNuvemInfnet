using MyEcommerce.Application.Dto;

namespace MyEcommerce.Application.Service;

public interface IClienteService
{
    Task<ClienteOutputDto> Create(ClienteInputDto dto);
    Task<List<ClienteOutputDto>> GetAll();
    Task<ClienteOutputDto> GetById(Guid id);
    Task<ClienteOutputDto> Update(Guid id, ClienteInputDto dto);
    Task<bool> Delete(Guid id);

}