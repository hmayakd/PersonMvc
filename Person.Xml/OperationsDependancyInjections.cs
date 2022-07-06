using Microsoft.Extensions.DependencyInjection;
namespace Person.Xml
{
    public static class OperationsDependancyInjections
    {
        public static IServiceCollection AddOperations(this IServiceCollection services)
        {
            services.AddScoped<IPersonOperations, PersonOperations>();
            return services;
        }

    }
}
