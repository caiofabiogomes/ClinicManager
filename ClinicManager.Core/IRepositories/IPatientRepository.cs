using ClinicManager.Core.Entities;

namespace ClinicManager.Core.IRepositories
{
    public interface IPatientRepository
    {
        Task<List<Patient>> GetAllAsync();

        Task<Patient> GetByIdAsync(Guid id);

        Task AddAsync(Patient patient);

        Task DeleteAsync(Patient patient);

    }
}
