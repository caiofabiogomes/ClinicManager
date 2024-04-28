using ClinicManager.Core.Entities;

namespace ClinicManager.Application.ViewModels
{
    public class ServiceNoteViewModel
    {
        public Guid Id { get; private set; } = new Guid();

        public string Name { get; private set; }

        public string Description { get; private set; }

        public decimal ValueOfServiceNote { get; private set; }

        public int DurationTime { get; private set; }

        public List<MedicalAppointment> MedicalAppointments { get; private set; }
    }
}
