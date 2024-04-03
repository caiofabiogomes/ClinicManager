using ClinicManager.Core.Entities;
using ClinicManager.Core.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Infrastructure.Persistence.Repositories
{
    public class ServiceNoteRepository : IServiceNoteRepository
    {
        private readonly ClinicManagerDbContext _context;

        public ServiceNoteRepository(ClinicManagerDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(ServiceNote serviceNote)
        {
            await _context.ServiceNotes.AddAsync(serviceNote);
        }


        public async Task DeleteAsync(ServiceNote serviceNote)
        {
            serviceNote.Delete();
        }


        public async Task<List<ServiceNote>> GetAllAsync()
        {
           return await _context.ServiceNotes.Where(x => !x.IsDeleted).ToListAsync();
        }

        public async Task<ServiceNote> GetByIdAsync(Guid id)
        {
            return await _context.ServiceNotes.Where(x => !x.IsDeleted).FirstOrDefaultAsync(x => x.Id == id);
        }

    }
}
