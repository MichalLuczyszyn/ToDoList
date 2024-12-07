using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ToDoList.Application;

public static class ApplicationConfiguration
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(IServiceCollection services)
        {

            services.AddMediatR(options =>
            {
                options.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly);
            });

            return services;
        }

        public static IServiceCollection AddInfrastructure(IServiceCollection services, IConfiguration configuration)
        {
            return services;
        }
    }
}