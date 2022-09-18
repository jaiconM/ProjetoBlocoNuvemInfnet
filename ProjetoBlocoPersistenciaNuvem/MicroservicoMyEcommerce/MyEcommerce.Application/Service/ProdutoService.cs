using AutoMapper;
using MyEcommerce.Application.Dto;
using MyEcommerce.CrossCutting.Exceptions;
using MyEcommerce.Data.AzureBlobStorageHelper;
using MyEcommerce.Domain;
using MyEcommerce.Domain.Repository;

namespace MyEcommerce.Application.Service;

public class ProdutoService : IProdutoService
{
    private readonly IProdutoRepository _produtoRepository;
    private readonly IMapper _mapper;
    private readonly IAzureBlobStorage _storage;

    public ProdutoService(IProdutoRepository produtoRepository, IMapper mapper, IAzureBlobStorage storage)
    {
        _produtoRepository = produtoRepository;
        _mapper = mapper;
        _storage = storage;
    }

    public async Task<ProdutoOutputDto> Create(ProdutoInputDto dto)
    {
        Produto produto = _mapper.Map<Produto>(dto);

        await TrateFoto(produto);

        await _produtoRepository.Create(produto);

        return _mapper.Map<ProdutoOutputDto>(produto);
    }

    public async Task<List<ProdutoOutputDto>> GetAll()
    {
        IEnumerable<Produto> result = await _produtoRepository.GetAll();

        return _mapper.Map<List<ProdutoOutputDto>>(result);
    }

    public async Task<ProdutoOutputDto> GetById(string id)
    {
        Produto? entity = await _produtoRepository.GetById(id);

        return entity == null ? throw new IdNotFoundException(nameof(Produto)) : _mapper.Map<ProdutoOutputDto>(entity);
    }

    public async Task<ProdutoOutputDto> Update(string id, ProdutoInputDto dto)
    {
        Produto? entity = await _produtoRepository.GetById(id);
        if (entity == null)
            throw new IdNotFoundException(nameof(Produto));

        entity = _mapper.Map(dto, entity);

        await TrateFoto(entity);

        await _produtoRepository.Update(entity);

        return _mapper.Map<ProdutoOutputDto>(entity);
    }

    public async Task<bool> Delete(string id)
    {
        Produto? entity = await _produtoRepository.GetById(id);
        if (entity == null)
            throw new IdNotFoundException(nameof(Produto));

        await _produtoRepository.RemoveById(id);

        return true;
    }

    private async Task TrateFoto(Produto produto)
    {
        if (string.IsNullOrEmpty(produto.LinkFoto))
            return;

        HttpClient httpClient = new();
        HttpResponseMessage response = await httpClient.GetAsync(produto.LinkFoto);

        if (response.IsSuccessStatusCode)
        {
            using Stream stream = await response.Content.ReadAsStreamAsync();

            var fileName = $"{Guid.NewGuid()}.jpg";

            var pathStorage = await _storage.UploadFile(fileName, "imagens", stream);

            produto.LinkFoto = pathStorage;
        }
    }
}