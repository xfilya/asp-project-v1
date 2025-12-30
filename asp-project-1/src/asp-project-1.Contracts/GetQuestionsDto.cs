namespace asp_project_1.Contracts;

public record GetQuestionsDto(string Search, Guid[] TagIds, int Page, int PageSize);