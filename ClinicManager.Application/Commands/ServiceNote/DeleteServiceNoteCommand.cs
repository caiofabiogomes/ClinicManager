using ClinicManager.Application.Abstractions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManager.Application.Commands.ServiceNote
{
    public class DeleteServiceNoteCommand : IRequest<Result<Guid>>
    {
        public DeleteServiceNoteCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; private set; }
    }
}
