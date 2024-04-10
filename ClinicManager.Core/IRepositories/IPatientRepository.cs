using ClinicManager.Core.Entities;
using ClinicManager.Core.ValueObjects;

namespace ClinicManager.Core.IRepositories
{
    public interface IPatientRepository
    {
        Task<List<Patient>> GetAllAsync();

        Task<Patient> GetByIdAsync(Guid id);

        Task<Patient> GetByCpfAsync(Cpf cpf);

        Task<Patient> GetByPhoneNumberAsync(PhoneNumber phoneNumber);

        Task AddAsync(Patient patient);

        Task DeleteAsync(Patient patient);

    }
}
