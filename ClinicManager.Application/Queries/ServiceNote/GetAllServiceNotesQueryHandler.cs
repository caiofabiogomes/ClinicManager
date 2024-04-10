using AutoMapper;
using ClinicManager.Application.Abstractions;
using ClinicManager.Application.ViewModels;
using ClinicManager.Infrastructure.Persistence;
using MediatR;

namespace ClinicManager.Application.Queries.ServiceNote
{
    public class GetAllServiceNotesQueryHandler : IRequestHandler<GetAllServiceNotesQuery, Result<List<ServiceNoteViewModel>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllServiceNotesQueryHandler(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;   
            _mapper = mapper;
        }

        public async Task<Result<List<ServiceNoteViewModel>>> Handle(GetAllServiceNotesQuery request, CancellationToken cancellationToken)
        {
            var serviceNotes = await _unitOfWork.ServiceNotes.GetAllAsync();

            var result = _mapper.Map<List<ServiceNoteViewModel>>(serviceNotes);

            return Result<List<ServiceNoteViewModel>>.Success(result,"Busca realizada com sucesso!");
        }
    }
}
