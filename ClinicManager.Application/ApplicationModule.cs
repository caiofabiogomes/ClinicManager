using ClinicManager.Application.Consumers;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace ClinicManager.Application
{
    public static class ApplicationModule
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        { 
            services
                .AddAMediatR()
                .AddAutoMapper()
                .AddConsumers();

            return services;
        }
        public static IServiceCollection AddAMediatR(this IServiceCollection services)
        {
            services.AddMediatR(typeof(ApplicationModule));

            return services;
        }

        public static IServiceCollection AddAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(ApplicationModule));

            return services;
        }
        public static IServiceCollection AddConsumers(this IServiceCollection services)
        {
            services.AddSingleton<MedicalAppointmentNotificationConsumer>();
            services.AddHostedService<MedicalAppointmentNotificationConsumer>();

            return services;
        }
    }
}
