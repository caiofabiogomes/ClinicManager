using ClinicManager.Application.Abstractions;
using ClinicManager.Application.ViewModels;
using MediatR;

namespace ClinicManager.Application.Commands.ServiceNote
{
    public class UpdateServiceNoteCommand : IRequest<Result<ServiceNoteViewModel>>
    {
        public UpdateServiceNoteCommand(Guid id,string name, string description, decimal valueOfServiceNote, int durationTime)
        {
            Id = id;
            Name = name;
            Description = description;
            ValueOfServiceNote = valueOfServiceNote;
            DurationTime = durationTime;
        }

        public Guid Id { get; private set; }

        public string Name { get; private set; }

        public string Description { get; private set; }

        public decimal ValueOfServiceNote { get; private set; }

        public int DurationTime { get; private set; }
    }
}
