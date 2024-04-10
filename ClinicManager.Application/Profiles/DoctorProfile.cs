using AutoMapper;
using ClinicManager.Application.ViewModels;
using ClinicManager.Core.Entities;

namespace ClinicManager.Application.Profiles
{
    public class DoctorProfile : Profile
    {
        public DoctorProfile()
        {
            CreateMap<Doctor, DoctorViewModel>();

            CreateMap<DoctorViewModel, Doctor>();
        }
    }
}
