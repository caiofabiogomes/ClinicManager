using ClinicManager.Application.Abstractions;
using MediatR;

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
