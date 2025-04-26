using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;

namespace Repositories.EFCore
{
    public class TechnicalDrawingSuccessStateRepository : RepositoryBase<TechnicalDrawingSuccessState>, ITechnicalDrawingSuccessStateRepository
    {
        public TechnicalDrawingSuccessStateRepository(RepositoryContext context) : base(context) { }

        public TechnicalDrawingSuccessState CreateTechnicalDrawingSuccessState(TechnicalDrawingSuccessState technicalDrawingSuccessState)
        {
            Create(technicalDrawingSuccessState);
            return technicalDrawingSuccessState;
        }

        public TechnicalDrawingSuccessState DeleteTechnicalDrawingSuccessState(TechnicalDrawingSuccessState technicalDrawingSuccessState)
        {
            Delete(technicalDrawingSuccessState);
            return technicalDrawingSuccessState;
        }

        public async Task<IEnumerable<TechnicalDrawingSuccessState>> GetAllTechnicalDrawingSuccessStateAsync(bool? trackChanges)
        {
            return await FindAll(trackChanges)
                .OrderBy(s => s.ID)
                .Include(s => s.Operator)
                .Include(s => s.User)
                .ToListAsync();
        }

        public async Task<IEnumerable<TechnicalDrawingSuccessState>> GetAllTechnicalDrawingSuccessStateByDrawingAsync(int id, bool? trackChanges)
        {
            return await FindAll(trackChanges)
                .Where(s => s.TechnicalDrawingID.Equals(id))
                .OrderBy(s => s.ID)
                .Include(s => s.Operator)
                .Include(s => s.User)
                .ToListAsync();
        }

        public async Task<TechnicalDrawingSuccessState> GetTechnicalDrawingSuccessStateByIdAsync(int id, bool? trackChanges)
        {
            return await FindByCondition(s => s.ID.Equals(id), trackChanges)
                .Include(s => s.Operator)
                .Include(s => s.User)
                .SingleOrDefaultAsync();
        }

        public TechnicalDrawingSuccessState UpdateTechnicalDrawingSuccessState(TechnicalDrawingSuccessState technicalDrawingSuccessState)
        {
            Update(technicalDrawingSuccessState);
            return technicalDrawingSuccessState;
        }
    }
}
