using ClinicManager.Application.Abstractions;
using ClinicManager.Infrastructure.Persistence;
using MediatR;

namespace ClinicManager.Application.Commands.ServiceNote
{
    public class DeleteServiceNoteCommandHandler : IRequestHandler<DeleteServiceNoteCommand, Result<Guid>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteServiceNoteCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<Guid>> Handle(DeleteServiceNoteCommand request, CancellationToken cancellationToken)
        {
            var serviceNote = await _unitOfWork.ServiceNotes.GetByIdAsync(request.Id);

            if (serviceNote == null)
                return Result<Guid>.Failure("Prontuário de serviço não encontrado.");

            await _unitOfWork.ServiceNotes.DeleteAsync(serviceNote);

            await _unitOfWork.CompleteAsync();

            return Result<Guid>.Success(serviceNote.Id, "Prontuário de serviço excluído com sucesso.");
        }
    }
}
