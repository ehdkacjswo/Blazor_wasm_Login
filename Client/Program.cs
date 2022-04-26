using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.JSInterop;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using lda.Client;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddTransient<JWTadder>();
builder.Services.AddSingleton<IJSInProcessRuntime>(services =>
    (IJSInProcessRuntime) services.GetRequiredService<IJSRuntime>());
builder.Services.AddSingleton<IGlobal, Global>();

builder.Services.AddHttpClient("WebAPI",client =>
{
    client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress);
}).AddHttpMessageHandler<JWTadder>();
builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>()
    .CreateClient("WebAPI"));

builder.Services.AddAntDesign();

await builder.Build().RunAsync();