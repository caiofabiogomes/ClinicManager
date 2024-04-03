using ClinicManager.Core.Entities;
using ClinicManager.Core.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Infrastructure.Persistence.Repositories
{
    public class MedicalAppointmentRepository : IMedicalAppointmentRepository
    {
        private readonly ClinicManagerDbContext _context;

        public MedicalAppointmentRepository(ClinicManagerDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(MedicalAppointment medicalAppointment)
        {
            await _context.MedicalAppointments.AddAsync(medicalAppointment);
        }

        public async Task DeleteAsync(MedicalAppointment medicalAppointment)
        {
            medicalAppointment.Delete();
        }

        public async Task<List<MedicalAppointment>> GetAllAsync()
        {
            return await _context.MedicalAppointments.Where(x => !x.IsDeleted).ToListAsync();
        }

        public async Task<MedicalAppointment> GetByIdAsync(Guid id)
        {
            return await _context.MedicalAppointments.Where(x => !x.IsDeleted).FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
