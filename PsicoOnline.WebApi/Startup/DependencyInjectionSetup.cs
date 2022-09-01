﻿using Microsoft.EntityFrameworkCore;
using PsicoOnline.Core.Interfaces;
using PsicoOnline.Infrastructure.Data;

namespace PsicoOnline.WebApi.Startup;

public static class DependencyInjectionSetup
{
    public static IServiceCollection RegistrarServicos(this IServiceCollection services, string connectionString)
    {
        services.AddControllers();
        services.AddScoped<IGrauParentescoRepository, GrauParentescoRepository>();
        services.AddScoped<IPacienteRepository, PacienteRepository>();
        services.AddScoped<IResponsavelRepository, ResponsavelRepository>();
        services.AddScoped<ISessaoRepository, SessaoRepository>();
        services.AddDbContext<EFContext>(options => options.UseSqlServer(connectionString));

        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        return services;
    }
}