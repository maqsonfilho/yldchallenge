using AutoMapper;
using YldChallenge.Domain.Dtos;

namespace YldChallenge.Domain.Mappings;

public class GameMappingProfile : Profile
{
    public GameMappingProfile()
    {
        CreateMap<GameDto, ItemDto>()
            .ForMember(dest => dest.Id, opts => opts.MapFrom(src => src.AppId));
    }
}
