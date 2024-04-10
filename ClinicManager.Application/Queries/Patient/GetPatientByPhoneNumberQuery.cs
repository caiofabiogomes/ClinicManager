using ClinicManager.Application.Abstractions;
using ClinicManager.Application.ViewModels;
using MediatR;

namespace ClinicManager.Application.Queries.Patient
{
    public class GetPatientByPhoneNumberQuery : IRequest<Result<PatientViewModel>>
    {
        public GetPatientByPhoneNumberQuery(string phoneNumber)
        {
            PhoneNumber = phoneNumber;
        }

        public string PhoneNumber { get; set; }
        
    }
}
