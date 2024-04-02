using ClinicManager.Core.Entities;
using ClinicManager.Core.IRepositories;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace ClinicManager.Infrastructure.Persistence.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        private readonly ClinicManagerDbContext _context;

        public PatientRepository(ClinicManagerDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Patient patient)
        {
            await _context.Patients.AddAsync(patient);
        }

        public async Task DeleteAsync(Patient patient)
        {
            patient.Delete();
        }

        public async Task<List<Patient>> GetAllAsync()
        {
            return await _context.Patients.Where(x => !x.IsDeleted).ToListAsync();
        }

        public async Task<Patient> GetByIdAsync(Guid id)
        {
            return await _context.Patients.Where(x => !x.IsDeleted).FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
