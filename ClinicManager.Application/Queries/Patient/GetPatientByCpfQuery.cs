using ClinicManager.Application.Abstractions;
using ClinicManager.Application.ViewModels;
using ClinicManager.Core.ValueObjects;
using MediatR;

namespace ClinicManager.Application.Queries.Patient
{
    public class GetPatientByCpfQuery : IRequest<Result<PatientViewModel>>
    {
        public GetPatientByCpfQuery(string cpf)
        {
            Cpf = cpf;
        }

        public string Cpf { get; private set; }
    } 
}
