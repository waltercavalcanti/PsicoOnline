namespace PsicoOnline.WebApi.Startup;

public static class SwaggerConfiguration
{
    public static WebApplication ConfigurarSwagger(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        return app;
    }
}