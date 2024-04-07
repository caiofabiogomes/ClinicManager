using ClinicManager.Application.Abstractions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManager.Application.Commands.ServiceNote
{
    public class CreateServiceNoteServiceCommand : IRequest<Result<Guid>>
    {
        public CreateServiceNoteServiceCommand(string name, string description, decimal valueOfServiceNote, int durationTime)
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
