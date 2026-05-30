using FuzzyNumbers.Blazor;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Holecek.FuzzyMath.FuzzyNumbers.Drawing;
using Holecek.FuzzyMath.FuzzyNumbers.Formatting;
using Holecek.FuzzyMath.FuzzyNumbers.Parsing;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddSingleton<IFuzzyNumberFormatter, FuzzyNumberFormatter>();
builder.Services.AddSingleton<IFuzzyNumberParser, FuzzyNumberParser>();
builder.Services.AddSingleton<IFuzzyNumberToGraphPointsConverter, FuzzyNumberToGraphPointsConverter>();

await builder.Build().RunAsync();
