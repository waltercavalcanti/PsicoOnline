global using PsicoOnline.UI.Models;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using PsicoOnline.UI;
using PsicoOnline.UI.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7016/api/") });
builder.Services.AddScoped<IGrauParentescoService, GrauParentescoService>();

await builder.Build().RunAsync();
