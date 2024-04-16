using Google.Apis.Calendar.v3.Data;

namespace ClinicManager.Infrastructure.ExternalServices.GoogleCalander
{
    public interface ISendNotificationGoogleCalendar
    {
        Task<Event> CreateQuickEventGoogleCalendar(string description, List<string> emailsToSend, DateTime startDate, DateTime endDate);
    }
}
