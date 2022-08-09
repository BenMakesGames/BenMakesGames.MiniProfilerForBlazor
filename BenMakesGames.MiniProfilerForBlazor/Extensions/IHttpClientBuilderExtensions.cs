using BenMakesGames.MiniProfilerForBlazor.HttpMessageHandlers;
using Microsoft.Extensions.DependencyInjection;

namespace BenMakesGames.MiniProfilerForBlazor.Extensions;

public static class IHttpClientBuilderExtensions
{
    public static IHttpClientBuilder AddMiniProfilerHandler(this IHttpClientBuilder httpClientBuilder)
    {
        if (IServiceCollectionExtensions.MiniProfilerRequestHandler == null)
            throw new InvalidOperationException("Call `services.AddMiniProfilerForBlazor()` first.");
        
        return httpClientBuilder.AddHttpMessageHandler(() => new MiniProfilerDelegatingHandler(IServiceCollectionExtensions.MiniProfilerRequestHandler));
    }
}