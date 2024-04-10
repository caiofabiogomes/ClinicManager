using AutoMapper;
using ClinicManager.Application.ViewModels;
using ClinicManager.Core.Entities;

namespace ClinicManager.Application.Profiles
{
    public class MedicalAppointmentProfile : Profile
    {
        public MedicalAppointmentProfile()
        {
            CreateMap<MedicalAppointment, MedicalAppointmentViewModel>();

            CreateMap<MedicalAppointmentViewModel, MedicalAppointment>();
        }
    }
}
