using AutoMapper;
using ClinicManager.Application.ViewModels;
using ClinicManager.Core.Entities;

namespace ClinicManager.Application.Profiles
{
    public class PatientProfile : Profile
    {
        public PatientProfile()
        {
            CreateMap<Patient, PatientViewModel>();

            CreateMap<PatientViewModel, Patient>();
        }
    }
}
