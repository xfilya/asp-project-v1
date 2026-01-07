namespace asp_project_1.Contracts.Questions;

public record UpdateQuestionDto(string Title, string Text, Guid[] TagIds);