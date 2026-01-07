using asp_project_1.Contracts.Questions;

namespace asp_project_1.Application.Questions;

public interface IQuestionsService
{
    Task<Guid> Create(CreateQuestionDto createQuestionDto, CancellationToken ct);
}