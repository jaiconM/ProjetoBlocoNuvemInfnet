using MyEcommerce.Application.Dto;
using MyEcommerce.Domain;

namespace MyEcommerce.Application.Profile;

public class ClienteProfile : AutoMapper.Profile
{
    public ClienteProfile()
    {
        CreateMap<Cliente, ClienteOutputDto>()
            .ForMember(dto => dto.Email, config => config.MapFrom(usuario => usuario.Email.Valor));

        CreateMap<ClienteInputDto, Cliente>()
            .ForPath(cliente => cliente.Email.Valor, config => config.MapFrom(dto => dto.Email));
    }
}
