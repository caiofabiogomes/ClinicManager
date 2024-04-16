using ClinicManager.Core.Entities;
using ClinicManager.Core.IRepositories;
using ClinicManager.Infrastructure.ExternalServices.GoogleCalander;
using ClinicManager.Infrastructure.Persistence;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ClinicManager.Application.Consumers
{
    public class MedicalAppointmentNotificationConsumer : BackgroundService
    {
        private readonly TimeSpan _interval = TimeSpan.FromHours(24);
        private readonly IServiceProvider _serviceProvider;

        public MedicalAppointmentNotificationConsumer(IServiceProvider servicesProvider)
        {
            _serviceProvider = servicesProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {

                var tomorrowDate = DateTime.Today.AddDays(1);
                var medicalAppointments = await GetMedicalAppointments(tomorrowDate);

                foreach (var medicalAppointment in medicalAppointments)
                {
                    var emailsToSend = new List<string>();
                    emailsToSend.Add(medicalAppointment.Patient.Email.Value);
                    emailsToSend.Add(medicalAppointment.Doctor.Email.Value);

                    await SendNotificationGoogleCalendar(medicalAppointment.Doctor.FirstName, emailsToSend, medicalAppointment.StartDate, medicalAppointment.EndDate);
                }

                await Task.Delay(_interval, stoppingToken);
            }
        }

        private async Task<List<MedicalAppointment>> GetMedicalAppointments(DateTime tomorrowDate)
        {
            List<MedicalAppointment> medicalAppointments = new List<MedicalAppointment>();
            using (var scope = _serviceProvider.CreateScope())
            {
                var medicalAppointmentRepository = scope.ServiceProvider.GetRequiredService<IMedicalAppointmentRepository>();

                medicalAppointments = await medicalAppointmentRepository.GetAllAsyncByDate(tomorrowDate);

            }
            return medicalAppointments;
        }

        private async Task SendNotificationGoogleCalendar(string medicalName,List<string> emails,DateTime startDate,DateTime endDate) 
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var sendNotificationGoogleCalendar = scope.ServiceProvider.GetRequiredService<ISendNotificationGoogleCalendar>();

                await sendNotificationGoogleCalendar.CreateQuickEventGoogleCalendar($"Consulta médica com {medicalName}", emails, startDate, endDate);
            }
        }
    }
}
