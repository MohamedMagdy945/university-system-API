using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace AppCoreSystem.API.Configurations;

public static class SwaggerConfiguration
{
    public static IServiceCollection AddSwaggerConfiguration(
        this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();

        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "AppCoreSystem API",
                Version = "v1"
            });

            options.SwaggerDoc("v2", new OpenApiInfo
            {
                Title = "AppCoreSystem API",
                Version = "v2"
            });

            // JWT
            const string securityScheme = "Bearer";

            options.AddSecurityDefinition(securityScheme, new OpenApiSecurityScheme
            {
                Name = "Authorization",
                Type = SecuritySchemeType.Http,
                Scheme = "bearer",
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Description = "Enter: Bearer {token}"
            });

            options.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = securityScheme
                        }
                    },
                    Array.Empty<string>()
                }
            });

            // XML Docs
            var xmlFile = $"{AppDomain.CurrentDomain.FriendlyName}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

            if (File.Exists(xmlPath))
                options.IncludeXmlComments(xmlPath);

            // Grouping
            options.DocInclusionPredicate((docName, apiDesc) =>
            {
                if (!apiDesc.GroupName?.Equals(docName, StringComparison.OrdinalIgnoreCase) ?? true)
                    return false;

                return true;
            });
        });

        return services;
    }

    public static WebApplication UseSwaggerDocumentation(
       this WebApplication app)
    {
        app.UseSwagger();

        app.UseSwaggerUI(options =>
        {
            options.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1");
            options.SwaggerEndpoint("/swagger/v2/swagger.json", "API V2");

            options.DisplayRequestDuration();
            options.EnablePersistAuthorization();
            options.DocExpansion(DocExpansion.None);
            options.DefaultModelsExpandDepth(-1);
            options.EnableFilter();
            options.EnableDeepLinking();
        });

        return app;
    }
}