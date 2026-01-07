using asp_project_1.Contracts.Questions;
using asp_project_1.Domain.Questions;
using FluentValidation;
using Microsoft.Extensions.Logging;

namespace asp_project_1.Application.Questions;

public class QuestionsService : IQuestionsService
{
    private readonly IQuestionsRepository _questionsRepository;
    private readonly ILogger<QuestionsService> _logger;
    private readonly IValidator<CreateQuestionDto> _validator;

    public QuestionsService(IQuestionsRepository questionsRepository, 
        ILogger<QuestionsService> logger, 
        IValidator<CreateQuestionDto> validator)
    {
        _questionsRepository = questionsRepository;
        _logger = logger;
        _validator = validator;
    }

    public async Task<Guid> Create(CreateQuestionDto createQuestionDto, CancellationToken ct)
    {
        //валидация входных данных
        var validationResult = await _validator.ValidateAsync(createQuestionDto, ct);
        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }
        
        //валидация бизнес логики
        int openUserCountQuestions = await _questionsRepository.GetOpenUserQuestionsAsync(createQuestionDto.UserId, ct);

        if (openUserCountQuestions > 3)
        {
            throw new Exception("Пользователь не может открыть более 3-х вопросов.");
        }
        
        var questionId = Guid.NewGuid();

        var question = new Question(
            questionId, 
            createQuestionDto.Title, 
            createQuestionDto.Text, 
            createQuestionDto.UserId, 
            null, 
            createQuestionDto.TagIds);
        
        await _questionsRepository.AddAsync(question, ct);
        
        _logger.LogInformation("Created question with id {questionId}", questionId);
        
        return questionId;
    }
    
    /*public async Task<IActionResult> Update(
        [FromRoute] Guid questionId,
        [FromBody] UpdateQuestionDto updateQuestionDto, 
        CancellationToken ct)
    {
        
    }
    
    public async Task<IActionResult> Delete( Guid questionId, CancellationToken ct)
    {
        
    }

    public async Task<IActionResult> SetBestAnswer(
         Guid questionId, 
         Guid bestAnswerId, 
         CancellationToken ct)
    {
        
    }

    public async Task<IActionResult> AddAnswer(
         Guid questionId, 
         AddAnswerDto addAnswerDto, 
         CancellationToken ct)
    {
        
    }*/
}