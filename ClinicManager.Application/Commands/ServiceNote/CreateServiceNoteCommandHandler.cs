using ClinicManager.Application.Abstractions;
using ClinicManager.Infrastructure.Persistence;
using MediatR;

namespace ClinicManager.Application.Commands.ServiceNote
{
    public class CreateServiceNoteCommandHandler : IRequestHandler<CreateServiceNoteCommand, Result<Guid>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateServiceNoteCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<Guid>> Handle(CreateServiceNoteCommand request, CancellationToken cancellationToken)
        {
            var serviceNote = new Core.Entities.ServiceNote(request.Name, request.Description, request.ValueOfServiceNote, request.DurationTime);

            await _unitOfWork.ServiceNotes.AddAsync(serviceNote);

            await _unitOfWork.CompleteAsync();

            return Result<Guid>.Success(serviceNote.Id,"Serviço criado com sucesso!");
        }
    }
}
