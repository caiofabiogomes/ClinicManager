using AutoMapper;
using ClinicManager.Application.Abstractions;
using ClinicManager.Application.ViewModels;
using ClinicManager.Infrastructure.Persistence;
using MediatR;

namespace ClinicManager.Application.Queries.ServiceNote
{
    public class GetServiceNoteByIdQueryHandler : IRequestHandler<GetServiceNoteByIdQuery, Result<ServiceNoteViewModel>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetServiceNoteByIdQueryHandler(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Result<ServiceNoteViewModel>> Handle(GetServiceNoteByIdQuery request, CancellationToken cancellationToken)
        {
            var serviceNote = await _unitOfWork.ServiceNotes.GetByIdAsync(request.Id);

            if (serviceNote == null)
                return Result<ServiceNoteViewModel>.NotFound("Nota de serviço não encontrada!");

            var result = _mapper.Map<ServiceNoteViewModel>(serviceNote);

            return Result<ServiceNoteViewModel>.Success(result,"busca realizada com sucesso!");
        }
    }
}
