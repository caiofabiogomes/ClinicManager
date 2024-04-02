using ClinicManager.Core.Entities;

namespace ClinicManager.Core.IRepositories
{
    public interface IDoctorRepository
    {
        Task<List<Doctor>> GetAllAsync();

        Task<Doctor> GetByIdAsync(Guid id);

        Task AddAsync(Doctor doctor);

        Task DeleteAsync(Doctor doctor);

    }
}
