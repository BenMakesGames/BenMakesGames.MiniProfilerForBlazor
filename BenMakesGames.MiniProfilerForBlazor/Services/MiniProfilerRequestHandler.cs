namespace BenMakesGames.MiniProfilerForBlazor.Services;

public interface IMiniProfilerRequestHandler
{
    event EventHandler<List<string>> OnRequest;
    
    void Add(string[] ids);
}

public class MiniProfilerRequestHandler: IMiniProfilerRequestHandler
{
    public event EventHandler<List<string>>? OnRequest;

    public void Add(string[] ids)
    {
        OnRequest?.Invoke(this, ids.ToList());
    }
}