global using PsicoOnline.UI.Models;
global using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using PsicoOnline.UI;
using PsicoOnline.UI.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7016/api/") });
builder.Services.AddScoped<IGrauParentescoService, GrauParentescoService>();
builder.Services.AddScoped<IPacienteService, PacienteService>();

await builder.Build().RunAsync();
