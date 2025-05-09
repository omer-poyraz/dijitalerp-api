using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;

namespace Repositories.EFCore
{
    public class TechnicalDrawingFailureStateRepository : RepositoryBase<TechnicalDrawingFailureState>, ITechnicalDrawingFailureStateRepository
    {
        public TechnicalDrawingFailureStateRepository(RepositoryContext context) : base(context) { }

        public TechnicalDrawingFailureState CreateTechnicalDrawingFailureState(TechnicalDrawingFailureState technicalDrawingFailureState)
        {
            Create(technicalDrawingFailureState);
            return technicalDrawingFailureState;
        }

        public TechnicalDrawingFailureState DeleteTechnicalDrawingFailureState(TechnicalDrawingFailureState technicalDrawingFailureState)
        {
            Delete(technicalDrawingFailureState);
            return technicalDrawingFailureState;
        }

        public async Task<IEnumerable<TechnicalDrawingFailureState>> GetAllTechnicalDrawingFailureStateAsync(bool? trackChanges)
        {
            return await FindAll(trackChanges)
                .OrderBy(s => s.ID)
                .Include(s => s.Operator)
                .Include(s => s.User)
                .ToListAsync();
        }

        public async Task<IEnumerable<TechnicalDrawingFailureState>> GetAllTechnicalDrawingFailureStateByDrawingAsync(int id, bool? trackChanges)
        {
            return await FindAll(trackChanges)
                .Where(s => s.TechnicalDrawingID.Equals(id))
                .OrderBy(s => s.ID)
                .Include(s => s.Operator)
                .Include(s => s.User)
                .ToListAsync();
        }

        public async Task<TechnicalDrawingFailureState> GetTechnicalDrawingFailureStateByIdAsync(int id, bool? trackChanges)
        {
            return await FindByCondition(s => s.ID.Equals(id), trackChanges)
                .Include(s => s.Operator)
                .Include(s => s.User)
                .SingleOrDefaultAsync();
        }

        public TechnicalDrawingFailureState UpdateTechnicalDrawingFailureByQualityState(TechnicalDrawingFailureState technicalDrawingFailureState)
        {
            Update(technicalDrawingFailureState);
            return technicalDrawingFailureState;
        }

        public TechnicalDrawingFailureState UpdateTechnicalDrawingFailureState(TechnicalDrawingFailureState technicalDrawingFailureState)
        {
            Update(technicalDrawingFailureState);
            return technicalDrawingFailureState;
        }
    }
}
