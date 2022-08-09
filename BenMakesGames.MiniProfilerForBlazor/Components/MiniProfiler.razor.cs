using BenMakesGames.MiniProfilerForBlazor.Services;
using Microsoft.AspNetCore.Components;

namespace BenMakesGames.MiniProfilerForBlazor.Components;

public partial class MiniProfiler: ComponentBase, IDisposable
{
    [Inject] private IMiniProfilerRequestHandler MiniProfilerRequestHandler { get; set; } = null!;

    [Parameter] public int ZIndex { get; set; } = 9999;

    public bool Visible { get; set; }
    public List<string>? Requests { get; set; }
    public List<string> Loaded { get; set; } = new();
    public string? Expanded { get; set; }

    protected override void OnInitialized()
    {
        MiniProfilerRequestHandler.OnRequest += GetRequest;
    }

    public void Dispose()
    {
        MiniProfilerRequestHandler.OnRequest -= GetRequest;
    }

    private void GetRequest(object? caller, List<string> requests)
    {
        Requests = requests;
        Loaded = Loaded.Where(requests.Contains).ToList();

        if (Expanded != null && !Requests.Contains(Expanded))
            Expanded = null;

        StateHasChanged();
    }

    public void Show(string miniProfilerId)
    {
        if (Expanded == miniProfilerId)
        {
            Expanded = null;
            return;
        }

        Expanded = miniProfilerId;

        if (!Loaded.Contains(miniProfilerId))
            Loaded.Add(miniProfilerId);
    }
}