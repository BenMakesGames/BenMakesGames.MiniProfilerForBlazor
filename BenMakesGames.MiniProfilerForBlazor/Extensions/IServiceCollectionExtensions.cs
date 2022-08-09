using BenMakesGames.MiniProfilerForBlazor.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BenMakesGames.MiniProfilerForBlazor.Extensions;

public static class IServiceCollectionExtensions
{
    public static IMiniProfilerRequestHandler? MiniProfilerRequestHandler { get; set; }

    public static IServiceCollection AddMiniProfilerForBlazor(this IServiceCollection services)
    {
        if(MiniProfilerRequestHandler != null)
            throw new InvalidOperationException("Cannot call `services.AddMiniProfilerForBlazor()` more than once.");
        
        MiniProfilerRequestHandler = new MiniProfilerRequestHandler();

        return services.AddSingleton(MiniProfilerRequestHandler);
    }
}