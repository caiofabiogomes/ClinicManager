namespace ClinicManager.Core.Entities
{
    public class ServiceNote : BaseEntity
    {
        public ServiceNote()
        {
            
        }

        public ServiceNote(string name, string description, decimal valueOfServiceNote, int durationTime)
        {
            Name = name;
            Description = description;
            ValueOfServiceNote = valueOfServiceNote;
            DurationTime = durationTime;
            MedicalAppointments = new List<MedicalAppointment>();
        }

        public string Name { get; private set; }

        public string Description { get; private set; }

        public decimal ValueOfServiceNote { get; private set; }

        public int DurationTime { get; private set; }

        public List<MedicalAppointment> MedicalAppointments { get; private set; }

        public void Update(string name, string description, decimal valueOfServiceNote, int durationTime)
        {
            Name = name;
            Description = description;
            ValueOfServiceNote = valueOfServiceNote;
            DurationTime = durationTime;
        }
    }
}
