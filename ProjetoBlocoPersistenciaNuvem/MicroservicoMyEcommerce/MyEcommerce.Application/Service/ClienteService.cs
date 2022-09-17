using AutoMapper;
using MyEcommerce.Application.Dto;
using MyEcommerce.CrossCutting.Exceptions;
using MyEcommerce.Domain;
using MyEcommerce.Domain.Repository;

namespace MyEcommerce.Application.Service;

public class ClienteService : IClienteService
{
    private readonly IClienteRepository _clienteRepository;
    private readonly IMapper _mapper;

    public ClienteService(IClienteRepository clienteRepository, IMapper mapper)
    {
        _clienteRepository = clienteRepository;
        _mapper = mapper;
    }

    public async Task<ClienteOutputDto> Create(ClienteInputDto dto)
    {
        Cliente cliente = _mapper.Map<Cliente>(dto);

        await _clienteRepository.Save(cliente);

        return _mapper.Map<ClienteOutputDto>(cliente);
    }

    public async Task<List<ClienteOutputDto>> GetAll()
    {
        IEnumerable<Cliente> result = await _clienteRepository.GetAll();

        return _mapper.Map<List<ClienteOutputDto>>(result);
    }

    public async Task<ClienteOutputDto> GetById(Guid id)
    {
        Cliente? entity = await _clienteRepository.Get(id);
        return entity == null ? throw new IdNotFoundException(nameof(Cliente)) : _mapper.Map<ClienteOutputDto>(entity);
    }

    public async Task<ClienteOutputDto> Update(Guid id, ClienteInputDto dto)
    {
        Cliente? entity = await _clienteRepository.Get(id);
        if (entity == null)
            throw new IdNotFoundException(nameof(Cliente));

        entity = _mapper.Map(dto, entity);

        await _clienteRepository.Update(entity);

        return _mapper.Map<ClienteOutputDto>(entity);
    }

    public async Task<bool> Delete(Guid id)
    {
        Cliente? entity = await _clienteRepository.Get(id);
        if (entity == null)
            throw new IdNotFoundException(nameof(Cliente));

        await _clienteRepository.Delete(entity);

        return true;
    }
}