using Entities.Models;

namespace Repositories.Contracts
{
    public interface ITechnicalDrawingQualityRepository : IRepositoryBase<TechnicalDrawingQuality>
    {
        Task<IEnumerable<TechnicalDrawingQuality>> GetAllTechnicalDrawingQualityAsync(bool? trackChanges);
        Task<IEnumerable<TechnicalDrawingQuality>> GetAllTechnicalDrawingQualityByFailureAsync(int id, bool? trackChanges);
        Task<TechnicalDrawingQuality> GetTechnicalDrawingQualityByIdAsync(int id, bool? trackChanges);
        TechnicalDrawingQuality CreateTechnicalDrawingQuality(TechnicalDrawingQuality technicalDrawingQuality);
        TechnicalDrawingQuality UpdateTechnicalDrawingQuality(TechnicalDrawingQuality technicalDrawingQuality);
        TechnicalDrawingQuality DeleteTechnicalDrawingQuality(TechnicalDrawingQuality technicalDrawingQuality);
    }
}
