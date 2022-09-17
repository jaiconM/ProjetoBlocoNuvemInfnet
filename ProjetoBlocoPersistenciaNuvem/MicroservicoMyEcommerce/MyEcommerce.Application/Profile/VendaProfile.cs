using MyEcommerce.Application.Dto;
using MyEcommerce.Domain;

namespace MyEcommerce.Application.Profile;

public class VendaProfile : AutoMapper.Profile
{
    public VendaProfile()
    {
        CreateMap<Venda, VendaOutputDto>();

        CreateMap<VendaInputDto, Venda>()
            .ForMember(dest => dest.Cliente, opt => opt.MapFrom(src => new Cliente(src.ClienteId)));

        CreateMap<ItemVenda, ItemVendaOutputDto>();

        CreateMap<ItemVendaInputDto, ItemVenda>();
    }
}
