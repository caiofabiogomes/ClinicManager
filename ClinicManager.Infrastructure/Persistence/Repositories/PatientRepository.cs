using ClinicManager.Core.Entities;
using ClinicManager.Core.IRepositories;
using ClinicManager.Core.ValueObjects;
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

        public async Task<Patient> GetByCpfAsync(Cpf cpf)
        {
            var cpfToSearch = cpf.CleanCpf(cpf.Value);
            
            return await _context.Patients.Where(x => !x.IsDeleted).FirstOrDefaultAsync(x => x.Cpf.CleanCpf(x.Cpf.Value) == cpfToSearch);
        }

        public async Task<Patient> GetByPhoneNumberAsync(PhoneNumber phoneNumber)
        {
            var phoneNumberToSearch = phoneNumber.CleanPhoneNumber(phoneNumber.Value);

            return await _context.Patients.Where(x => !x.IsDeleted).FirstOrDefaultAsync(x => x.Cpf.CleanCpf(x.Cpf.Value) == phoneNumberToSearch);
        }

        public async Task<Patient> GetByEmailAndPasswordAsync(string email, string password)
        {
            return await _context.Patients.Where(x => !x.IsDeleted).FirstOrDefaultAsync(x => x.Email.Value == email && x.Password == password);
        }
    }
}
