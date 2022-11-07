using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace HR.LeaveManagement.Application
{
    // This class is created manually!
    // Abstracting DI only to this project
    public static class ApplicationServicesRegistration
    {
        public static IServiceCollection ConfigureApplicationServices(this IServiceCollection services)
        {
            // Old way 
            // services.AddAutoMapper(typeof(MappingProfile));
            // But it required of appyling separately to every mapping you had
            // Now its done for all mappings with Profile as base class
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
