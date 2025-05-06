using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;

namespace Repositories.EFCore
{
    public class TechnicalDrawingQualityRepository : RepositoryBase<TechnicalDrawingQuality>, ITechnicalDrawingQualityRepository
    {
        public TechnicalDrawingQualityRepository(RepositoryContext context) : base(context) { }

        public TechnicalDrawingQuality CreateTechnicalDrawingQuality(TechnicalDrawingQuality technicalDrawingQuality)
        {
            Create(technicalDrawingQuality);
            return technicalDrawingQuality;
        }

        public TechnicalDrawingQuality DeleteTechnicalDrawingQuality(TechnicalDrawingQuality technicalDrawingQuality)
        {
            Delete(technicalDrawingQuality);
            return technicalDrawingQuality;
        }

        public async Task<IEnumerable<TechnicalDrawingQuality>> GetAllTechnicalDrawingQualityAsync(bool? trackChanges)
        {
            return await FindAll(trackChanges)
                .OrderBy(s => s.ID)
                .Include(s => s.QualityOfficer)
                .ToListAsync();
        }

        public async Task<IEnumerable<TechnicalDrawingQuality>> GetAllTechnicalDrawingQualityByFailureAsync(int id, bool? trackChanges)
        {
            return await FindAll(trackChanges)
                .Where(s => s.TechnicalDrawingFailureStateID.Equals(id))
                .OrderBy(s => s.ID)
                .Include(s => s.QualityOfficer)
                .ToListAsync();
        }

        public async Task<TechnicalDrawingQuality> GetTechnicalDrawingQualityByIdAsync(int id, bool? trackChanges)
        {
            return await FindByCondition(s => s.ID.Equals(id), trackChanges)
                .Include(s => s.QualityOfficer)
                .SingleOrDefaultAsync();
        }

        public TechnicalDrawingQuality UpdateTechnicalDrawingQuality(TechnicalDrawingQuality technicalDrawingQuality)
        {
            Update(technicalDrawingQuality);
            return technicalDrawingQuality;
        }
    }
}
