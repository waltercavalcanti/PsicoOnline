using Microsoft.EntityFrameworkCore;
using PsicoOnline.WebApi.Startup;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.RegistrarServicos(builder.Configuration.GetConnectionString("PsicoOnlineDBConnStr"));

var app = builder.Build();

// Configure the HTTP request pipeline.
app.ConfigurarSwagger();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
