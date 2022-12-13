using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using PsicoOnline.Core.Interfaces;
using PsicoOnline.Infrastructure.Data;

namespace PsicoOnline.WebApi.Startup;

public static class DependencyInjectionSetup
{
    public static IServiceCollection RegistrarServicos(this IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddDefaultPolicy(policy =>
            {
                policy.WithOrigins("https://localhost:7121")
                      .AllowAnyHeader()
                      .AllowAnyMethod();
            });
        });

        services.AddControllers().AddOData(options => options.Select().Count().Filter().OrderBy().SetMaxTop(50).SkipToken().Expand());
        services.AddScoped<IGrauParentescoRepository, GrauParentescoRepository>();
        services.AddScoped<IPacienteRepository, PacienteRepository>();
        services.AddScoped<IResponsavelRepository, ResponsavelRepository>();
        services.AddScoped<ISessaoRepository, SessaoRepository>();
        services.AddDbContext<EFContext>((provider, options) => options.UseSqlServer(provider.GetRequiredService<IOptions<AppSettings>>().Value.ConnectionStrings.PsicoOnlineDBConnStr));

        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        return services;
    }
}