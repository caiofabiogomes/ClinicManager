using ClinicManager.Application.Abstractions;
using ClinicManager.Application.ViewModels;
using MediatR;

namespace ClinicManager.Application.Queries.ServiceNote
{
    public class GetAllServiceNotesQuery : IRequest<Result<List<ServiceNoteViewModel>>>
    {
        public GetAllServiceNotesQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; private set; }

    }
}
