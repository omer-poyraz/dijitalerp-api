using Entities.Models;

namespace Repositories.Contracts
{
    public interface ITechnicalDrawingSuccessStateRepository : IRepositoryBase<TechnicalDrawingSuccessState>
    {
        Task<IEnumerable<TechnicalDrawingSuccessState>> GetAllTechnicalDrawingSuccessStateAsync(bool? trackChanges);
        Task<IEnumerable<TechnicalDrawingSuccessState>> GetAllTechnicalDrawingSuccessStateByDrawingAsync(int id, bool? trackChanges);
        Task<TechnicalDrawingSuccessState> GetTechnicalDrawingSuccessStateByIdAsync(int id, bool? trackChanges);
        TechnicalDrawingSuccessState CreateTechnicalDrawingSuccessState(TechnicalDrawingSuccessState technicalDrawingSuccessState);
        TechnicalDrawingSuccessState UpdateTechnicalDrawingSuccessState(TechnicalDrawingSuccessState technicalDrawingSuccessState);
        TechnicalDrawingSuccessState DeleteTechnicalDrawingSuccessState(TechnicalDrawingSuccessState technicalDrawingSuccessState);
    }
}
