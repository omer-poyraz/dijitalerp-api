using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;

namespace Repositories.EFCore
{
    public class TechnicalDrawingRepository : RepositoryBase<TechnicalDrawing>, ITechnicalDrawingRepository
    {
        public TechnicalDrawingRepository(RepositoryContext context) : base(context) { }

        public TechnicalDrawing CreateTechnicalDrawing(TechnicalDrawing technicalDrawing)
        {
            Create(technicalDrawing);
            return technicalDrawing;
        }

        public TechnicalDrawing DeleteTechnicalDrawing(TechnicalDrawing technicalDrawing)
        {
            Delete(technicalDrawing);
            return technicalDrawing;
        }

        public async Task<IEnumerable<TechnicalDrawing>> GetAllTechnicalDrawingAsync(bool? trackChanges)
        {
            return await FindAll(trackChanges)
                .OrderBy(s => s.ID)
                .Include(s => s.BasariliDurumlar)
                .Include(s => s.BasarisizDurumlar)
                .Include(s => s.Responible)
                .Include(s => s.PersonInCharge)
                .Include(s => s.User)
                .ToListAsync();
        }

        public async Task<TechnicalDrawing> GetTechnicalDrawingByIdAsync(int id, bool? trackChanges)
        {
            return await FindByCondition(s => s.ID.Equals(id), trackChanges)
                .Include(s => s.BasariliDurumlar)
                .Include(s => s.BasarisizDurumlar)
                .Include(s => s.Responible)
                .Include(s => s.PersonInCharge)
                .Include(s => s.User)
                .SingleOrDefaultAsync();
        }

        public TechnicalDrawing AddFileTechnicalDrawing(TechnicalDrawing technicalDrawing)
        {
            Update(technicalDrawing);
            return technicalDrawing;
        }

        public TechnicalDrawing UpdateTechnicalDrawing(TechnicalDrawing technicalDrawing)
        {
            Update(technicalDrawing);
            return technicalDrawing;
        }
    }
}
