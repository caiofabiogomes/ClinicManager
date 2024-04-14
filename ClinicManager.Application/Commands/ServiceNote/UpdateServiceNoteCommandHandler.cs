using AutoMapper;
using ClinicManager.Application.Abstractions;
using ClinicManager.Application.ViewModels;
using ClinicManager.Infrastructure.Persistence;
using MediatR;

namespace ClinicManager.Application.Commands.ServiceNote
{
    public class UpdateServiceNoteCommandHandler : IRequestHandler<UpdateServiceNoteCommand, Result<ServiceNoteViewModel>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;   

        public UpdateServiceNoteCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<ServiceNoteViewModel>> Handle(UpdateServiceNoteCommand request, CancellationToken cancellationToken)
        {
            var serviceNote = await _unitOfWork.ServiceNotes.GetByIdAsync(request.Id);

            if (serviceNote is null)
                return Result<ServiceNoteViewModel>.NotFound("Service note not found");

            serviceNote.Update(request.Name,request.Description,request.ValueOfServiceNote,request.DurationTime);

            await _unitOfWork.CompleteAsync(); 

            var result = _mapper.Map<ServiceNoteViewModel>(serviceNote);

            return Result<ServiceNoteViewModel>.Success(result);
        }
    }
}
