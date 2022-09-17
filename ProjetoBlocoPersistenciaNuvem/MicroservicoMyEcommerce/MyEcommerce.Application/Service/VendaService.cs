using AutoMapper;
using MyEcommerce.Application.Dto;
using MyEcommerce.CrossCutting.Exceptions;
using MyEcommerce.Domain;
using MyEcommerce.Domain.Repository;

namespace MyEcommerce.Application.Service;

public class VendaService : IVendaService
{
    private readonly IVendaRepository _vendaRepository;
    private readonly IClienteRepository _clienteRepository;
    private readonly IMapper _mapper;

    public VendaService(IVendaRepository vendaRepository, IClienteRepository clienteRepository, IMapper mapper)
    {
        _vendaRepository = vendaRepository;
        _clienteRepository = clienteRepository;
        _mapper = mapper;
    }

    public async Task<VendaOutputDto> Create(VendaInputDto dto)
    {
        Venda venda = _mapper.Map<Venda>(dto);
        Cliente? cliente = await _clienteRepository.Get(venda.Cliente.Id);

        if (cliente == null)
            throw new IdNotFoundException(nameof(Cliente));

        venda.Cliente = cliente;

        await _vendaRepository.Save(venda);

        return _mapper.Map<VendaOutputDto>(venda);
    }

    public async Task<List<VendaOutputDto>> GetAll()
    {
        IEnumerable<Venda> result = await _vendaRepository.GetAllWithIncludes();

        return _mapper.Map<List<VendaOutputDto>>(result);
    }

    public async Task<VendaOutputDto> GetById(Guid id)
    {
        Venda? entity = await _vendaRepository.GetByIdWithIncludes(id);
        return entity == null ? throw new IdNotFoundException(nameof(Venda)) : _mapper.Map<VendaOutputDto>(entity);
    }

    public async Task<VendaOutputDto> Update(Guid id, VendaInputDto dto)
    {
        Venda? entity = await _vendaRepository.Get(id);
        if (entity == null)
            throw new IdNotFoundException(nameof(Venda));

        entity = _mapper.Map(dto, entity);

        Cliente? cliente = await _clienteRepository.Get(entity.Cliente.Id);

        if (cliente == null)
            throw new IdNotFoundException(nameof(Cliente));

        entity.Cliente = cliente;

        await _vendaRepository.Update(entity);

        return _mapper.Map<VendaOutputDto>(entity);
    }

    public async Task<bool> Delete(Guid id)
    {
        Venda? entity = await _vendaRepository.Get(id);
        if (entity == null)
            throw new IdNotFoundException(nameof(Venda));

        await _vendaRepository.Delete(entity);

        return true;
    }
}