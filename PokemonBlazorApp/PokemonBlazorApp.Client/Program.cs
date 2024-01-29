using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using PokemonBlazorApp.Client.Services;
using PokemonBlazorApp.Client.Services.Contracts;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

RegiterServices(builder.Services);

await builder.Build().RunAsync();

static void RegiterServices(IServiceCollection services)
{
    services.AddHttpClient();
    services.AddScoped<IPokemonService, PokemonService>();
}
