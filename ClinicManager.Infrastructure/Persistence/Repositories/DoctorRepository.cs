using ClinicManager.Core.Entities;
using ClinicManager.Core.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Infrastructure.Persistence.Repositories
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly ClinicManagerDbContext _context;

        public DoctorRepository(ClinicManagerDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Doctor doctor)
        { 
            await _context.Doctors.AddAsync(doctor);
        }

        public async Task DeleteAsync(Doctor doctor)
        {
            doctor.Delete();
        }

        public async Task<List<Doctor>> GetAllAsync()
        {
           return await _context.Doctors.Where(x => !x.IsDeleted).ToListAsync();
        }

        public async Task<Doctor> GetByIdAsync(Guid id)
        {
            return await _context.Doctors.Where(x => !x.IsDeleted).FirstOrDefaultAsync( x => x.Id == id);
        }
    }
}
