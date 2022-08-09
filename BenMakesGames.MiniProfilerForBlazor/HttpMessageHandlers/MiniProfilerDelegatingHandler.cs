using System.Text.Json;
using BenMakesGames.MiniProfilerForBlazor.Services;

namespace BenMakesGames.MiniProfilerForBlazor.HttpMessageHandlers;

public class MiniProfilerDelegatingHandler : DelegatingHandler
{
    private IMiniProfilerRequestHandler MiniProfilerRequestHandler { get; }

    public MiniProfilerDelegatingHandler(IMiniProfilerRequestHandler miniProfilerRequestHandler)
    {
        MiniProfilerRequestHandler = miniProfilerRequestHandler;
    }

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        var response = await base.SendAsync(request, cancellationToken);

        if (response.Headers.TryGetValues("x-miniprofiler-ids", out var miniProfilerHeaders))
        {
            var miniProfilerIds = miniProfilerHeaders.FirstOrDefault();

            if (miniProfilerIds != null && JsonSerializer.Deserialize<string[]>(miniProfilerIds) is string[] ids)
                MiniProfilerRequestHandler.Add(ids);
        }

        return response;
    }
}
