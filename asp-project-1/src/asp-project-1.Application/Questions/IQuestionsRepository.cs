using asp_project_1.Domain.Questions;

namespace asp_project_1.Application.Questions;

public interface IQuestionsRepository
{
    Task<Guid> AddAsync(Question question, CancellationToken cancellationToken);
    Task<Guid> SaveAsync(Question question, CancellationToken cancellationToken);
    Task<Guid> DeleteAsync(Guid questionId, CancellationToken cancellationToken);
    Task<Guid> GetByIdAsync(Guid questionId, CancellationToken cancellationToken);
    Task<int> GetOpenUserQuestionsAsync(Guid userId, CancellationToken cancellationToken);
}