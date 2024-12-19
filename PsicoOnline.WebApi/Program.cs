using PsicoOnline.WebApi;
using PsicoOnline.WebApi.Startup;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<AppSettings>(appSettings =>
{
	builder.Configuration.Bind(appSettings);
});
builder.Services.RegistrarServicos();

var app = builder.Build();

//app.ConfigurarSwagger();
app.ConfigurarScalar();

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();
