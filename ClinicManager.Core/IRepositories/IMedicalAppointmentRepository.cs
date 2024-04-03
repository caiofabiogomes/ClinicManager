using ClinicManager.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManager.Core.IRepositories
{
    public interface IMedicalAppointmentRepository
    {
        Task<List<MedicalAppointment>> GetAllAsync();

        Task<MedicalAppointment> GetByIdAsync(Guid id);

        Task AddAsync(MedicalAppointment medicalAppointment);

        Task DeleteAsync(MedicalAppointment medicalAppointment);
    }
}
