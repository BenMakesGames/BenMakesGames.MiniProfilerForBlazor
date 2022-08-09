## What is This?

`BenMakesGames.MiniProfilerForBlazor` adds a service & component for displaying MiniProfiler results on a Blazor WebAssembly front-end.

## Installation & Configuration

These instructions assume you are using Refit (https://github.com/reactiveui/refit) to talk to your API. It is not necessary to use Refit, but you'll need to improvise a little to get `MiniProfilerForBlazor` working without Refit.

### API Project

#### Install MiniProfiler in API Project

Install & configure MiniProfiler: https://miniprofiler.com/dotnet/AspDotNetCore

* DON'T follow instructions for setting up `.cshtml` files; these do not apply to a Blazor WebAssembly project

#### Validate Installation

1. Run the project, and view the website in your browser of choice
2. In the browser's developer tools, view the details for any XHR request
3. Verify that the response headers contains an `x-miniprofiler-ids` header
   * If the `x-miniprofiler-ids` header is not present, MiniProfiler has not been configured, and `MiniProfilerForBlazor` will not work

### WebAssembly Project

#### Install this Package

Add `BenMakesGames.MiniProfilerForBlazor` to your Blazor WebAssembly project.

#### Register Service

In your WebAssembly's `Program.cs`:

```c#
services.AddMiniProfilerForBlazor();
```

#### Register Handler (Refit)

```c#
services.AddRefitClient<...>() // <-- your registration of your refit client
    .AddMiniProfilerHandler();
```

`.AddMiniProfilerHandler()` works with any `IHttpClientBuilder`; it does not require Refit.

#### Add MiniProfiler to UI

In your `App.razor`, main layout, or wherever you want MiniProfiler to appear, add:

```html
@using BenMakesGames.MiniProfilerForBlazor.Components // or add this to your _Imports.razor; up to you

...

<MiniProfiler />
```

##### Component Options

* `int ZIndex` z-index to display the MiniProfiler button & panel; defaults to 9999
  * example: `<MiniProfiler ZIndex="39" />`
