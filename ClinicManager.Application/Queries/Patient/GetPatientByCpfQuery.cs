using ClinicManager.Application.Abstractions;
using ClinicManager.Application.ViewModels;
using ClinicManager.Core.ValueObjects;
using MediatR;

namespace ClinicManager.Application.Queries.Patient
{
    public class GetPatientByCpfQuery : IRequest<Result<PatientViewModel>>
    {
        public GetPatientByCpfQuery(Cpf cpf)
        {
            Cpf = cpf;
        }

        public Cpf Cpf { get; private set; }
    } 
}
