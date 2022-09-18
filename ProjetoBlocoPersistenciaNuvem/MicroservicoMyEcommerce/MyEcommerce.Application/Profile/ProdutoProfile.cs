using MyEcommerce.Application.Dto;
using MyEcommerce.Domain;

namespace MyEcommerce.Application.Profile;

public class ProdutoProfile : AutoMapper.Profile
{
    public ProdutoProfile()
    {
        CreateMap<Produto, ProdutoOutputDto>();

        CreateMap<ProdutoInputDto, Produto>();
    }
}
