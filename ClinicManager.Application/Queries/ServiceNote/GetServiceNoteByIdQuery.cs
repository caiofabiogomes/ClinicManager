using ClinicManager.Application.Abstractions;
using ClinicManager.Application.ViewModels;
using MediatR;

namespace ClinicManager.Application.Queries.ServiceNote
{
    public class GetServiceNoteByIdQuery : IRequest<Result<ServiceNoteViewModel>>
    {
        public Guid Id { get; private set; }

        public GetServiceNoteByIdQuery(Guid id)
        {
            Id = id;
        }
    } 
}
