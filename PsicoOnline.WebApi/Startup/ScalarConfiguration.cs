using Scalar.AspNetCore;

namespace PsicoOnline.WebApi.Startup;

public static class ScalarConfiguration
{
	public static WebApplication ConfigurarScalar(this WebApplication app)
	{
		if (app.Environment.IsDevelopment())
		{
			app.MapScalarApiReference();
			app.MapOpenApi();
		}

		return app;
	}
}