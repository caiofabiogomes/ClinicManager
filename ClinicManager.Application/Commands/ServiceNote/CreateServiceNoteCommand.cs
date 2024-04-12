using ClinicManager.Application.Abstractions;
using MediatR;

namespace ClinicManager.Application.Commands.ServiceNote
{
    public class CreateServiceNoteCommand : IRequest<Result<Guid>>
    {
        public CreateServiceNoteCommand(string name, string description, decimal valueOfServiceNote, int durationTime)
        {
            Name = name;
            Description = description;
            ValueOfServiceNote = valueOfServiceNote;
            DurationTime = durationTime;
        }

        public string Name { get; private set; }

        public string Description { get; private set; }

        public decimal ValueOfServiceNote { get; private set; }

        public int DurationTime { get; private set; }
    }
}
