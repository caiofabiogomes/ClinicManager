using ClinicManager.Core.Entities;

namespace ClinicManager.Core.IRepositories
{
    public interface IServiceNoteRepository
    {
        Task<List<ServiceNote>> GetAllAsync();

        Task<ServiceNote> GetByIdAsync(Guid id);

        Task AddAsync(ServiceNote serviceNote);

        Task DeleteAsync(ServiceNote serviceNote);
    }
}
