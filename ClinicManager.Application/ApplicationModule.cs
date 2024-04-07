using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace ClinicManager.Application
{
    public static class ApplicationModule
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        { 
            services.AddAMediatR();

            return services;
        }
        public static IServiceCollection AddAMediatR(this IServiceCollection services)
        {
            services.AddMediatR(typeof(ApplicationModule));

            return services;
        }
    }
}
