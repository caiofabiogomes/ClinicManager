using AutoMapper;
using ClinicManager.Application.ViewModels;
using ClinicManager.Core.Entities;

namespace ClinicManager.Application.Profiles
{
    public class ServiceNoteProfile : Profile
    {
       public ServiceNoteProfile()
        {
            CreateMap<ServiceNote, ServiceNoteViewModel>();

            CreateMap<ServiceNoteViewModel, ServiceNote>();
        }
    }
}
