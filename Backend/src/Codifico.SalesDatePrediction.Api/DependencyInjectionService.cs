using Microsoft.OpenApi.Models;

namespace Codifico.SalesDatePrediction.Api
{
    public static class DependencyInjectionService
    {
        public static IServiceCollection AddWebApi(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Codifico SalesDatePrediction API",
                    Description = "Administración de APIs para SalesDatePrediction App"

                });
            });
            return services;
        }
    }
}
