using Entities.Models;

namespace Repositories.Contracts
{
    public interface ITechnicalDrawingRepository : IRepositoryBase<TechnicalDrawing>
    {
        Task<IEnumerable<TechnicalDrawing>> GetAllTechnicalDrawingAsync(bool? trackChanges);
        Task<TechnicalDrawing> GetTechnicalDrawingByIdAsync(int id, bool? trackChanges);
        TechnicalDrawing CreateTechnicalDrawing(TechnicalDrawing technicalDrawing);
        TechnicalDrawing UpdateTechnicalDrawing(TechnicalDrawing technicalDrawing);
        TechnicalDrawing AddFileTechnicalDrawing(TechnicalDrawing technicalDrawing);
        TechnicalDrawing DeleteTechnicalDrawing(TechnicalDrawing technicalDrawing);
    }
}
