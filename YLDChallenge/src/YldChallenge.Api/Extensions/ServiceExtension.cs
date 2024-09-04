using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using YldChallenge.Application.Interfaces;
using YldChallenge.Application.Services;
using YldChallenge.Domain.Mappings;

namespace YldChallenge.Api.Extensions;

public static class ServiceExtension
{
    public static void ConfigureLogger(this IServiceCollection services)
        => services.AddLogging();

    public static void ConfigureMapping(this IServiceCollection services)
    {
        services.Configure<ApiBehaviorOptions>(options => 
        { 
            options.SuppressModelStateInvalidFilter = true; 
        });

        var mapperConfig = new MapperConfiguration(map =>
        {
            map.AddProfile<GameMappingProfile>();
        });

        services.AddSingleton(mapperConfig.CreateMapper());
    }

    public static void RegisterDependencies(this IServiceCollection services)
    {
        services.AddScoped<IGameService, GameService>();
    }
}
