namespace asp_project_1.Contracts;

public record UpdateQuestionDto(string Title, string Text, Guid[] TagIds);