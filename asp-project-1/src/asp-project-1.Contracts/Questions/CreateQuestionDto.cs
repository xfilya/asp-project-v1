namespace asp_project_1.Contracts.Questions;

public record CreateQuestionDto(string Title, string Text, Guid UserId, Guid[] TagIds);