using FuzzyNumbers.Blazor;
using FuzzyNumbers.Blazor.Interfaces;
using FuzzyNumbers.Blazor.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddSingleton<IFuzzyNumberFormatter, FuzzyNumberFormatter>();
builder.Services.AddSingleton<IFuzzyNumberParser, FuzzyNumberParser>();
builder.Services.AddSingleton<IFuzzyNumberToGraphPointsConverter, FuzzyNumberToGraphPointsConverter>();

await builder.Build().RunAsync();
