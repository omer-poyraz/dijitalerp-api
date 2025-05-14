using Entities.Models;

namespace Repositories.Contracts
{
    public interface ITechnicalDrawingFailureStateRepository : IRepositoryBase<TechnicalDrawingFailureState>
    {
        Task<IEnumerable<TechnicalDrawingFailureState>> GetAllTechnicalDrawingFailureStateAsync(bool? trackChanges);
        Task<IEnumerable<TechnicalDrawingFailureState>> GetAllTechnicalDrawingFailureStateByDrawingAsync(int id, bool? trackChanges);
        Task<IEnumerable<TechnicalDrawingFailureState>> GetAllTechnicalDrawingFailureStateByQualityOfficerAsync(string userId, bool? trackChanges);
        Task<IEnumerable<TechnicalDrawingFailureState>> GetAllTechnicalDrawingFailureStateByCMMUserAsync(string userId, bool? trackChanges);
        Task<TechnicalDrawingFailureState> GetTechnicalDrawingFailureStateByIdAsync(int id, bool? trackChanges);
        TechnicalDrawingFailureState CreateTechnicalDrawingFailureState(TechnicalDrawingFailureState technicalDrawingFailureState);
        TechnicalDrawingFailureState UpdateTechnicalDrawingFailureState(TechnicalDrawingFailureState technicalDrawingFailureState);
        TechnicalDrawingFailureState UpdateTechnicalDrawingFailureByQualityState(TechnicalDrawingFailureState technicalDrawingFailureState);
        TechnicalDrawingFailureState UpdateTechnicalDrawingFailureByCMMState(TechnicalDrawingFailureState technicalDrawingFailureState);
        TechnicalDrawingFailureState DeleteTechnicalDrawingFailureState(TechnicalDrawingFailureState technicalDrawingFailureState);
    }
}
