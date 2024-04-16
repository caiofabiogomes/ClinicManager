using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;
using Google.Apis.Services;

namespace ClinicManager.Infrastructure.ExternalServices.GoogleCalander
{
    public class SendNotificationGoogleCalander : ISendNotificationGoogleCalendar
    {
        const string CALENDAR_ID = "primary";
        static string[] Scopes = { CalendarService.Scope.CalendarEvents };

        public async Task<Event> CreateQuickEventGoogleCalendar(string description, List<string> emailsToSend, DateTime startDate, DateTime endDate)
        {
            var services = await ConnectGoogleAgenda();

            var attendees = emailsToSend.Select(email => new EventAttendee() { Email = email }).ToList();

            Event newEvent = new Event()
            {
                Summary = "Consulta médica",
                Description = description,
                Attendees = attendees,
                Start = new EventDateTime()
                {
                    DateTime = startDate,
                    TimeZone = "America/Sao_Paulo"
                },
                End = new EventDateTime()
                {
                    DateTime = endDate,
                    TimeZone = "America/Sao_Paulo"
                },
            };
            var requestCreate = services.Events.Insert(newEvent, CALENDAR_ID).Execute();

            return requestCreate;
        }

        private static async Task<CalendarService> ConnectGoogleAgenda()
        {
            string applicationName = "ClinicManager";

            var credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(
            new ClientSecrets
            {
                ClientId = "ClientId",
                ClientSecret = "ClientSecret"
            },
            Scopes,
            Environment.UserName,
            CancellationToken.None);


            var services = new CalendarService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = applicationName
            });

            return services;
        }

    }
}
