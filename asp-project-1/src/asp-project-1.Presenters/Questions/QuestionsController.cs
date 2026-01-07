using asp_project_1.Application.Questions;
using asp_project_1.Contracts.Questions;
using Microsoft.AspNetCore.Mvc;

namespace asp_project_1.Presenters.Questions;

[ApiController]
[Route("[controller]")]
public class QuestionsController : ControllerBase
{
    private readonly IQuestionsService _questionsService;

    public QuestionsController(IQuestionsService questionsService)
    {
        _questionsService = questionsService;
    }
    
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateQuestionDto createQuestionDto, CancellationToken ct)
    {
        var questionId = await _questionsService.Create(createQuestionDto, ct);
        return Ok("Question created with id" +  questionId);    
    }

    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] GetQuestionsDto getQuestionsDto, CancellationToken ct)
    {
        return  Ok("Questions found");
    }
    
    [HttpGet("{questionId:guid}")]
    public async Task<IActionResult> GetById([FromRoute] Guid questionId, CancellationToken ct)
    {
        return  Ok("Question by id found");
    }
    
    [HttpPut("{questionId:guid}")]
    public async Task<IActionResult> Update(
        [FromRoute] Guid questionId,
        [FromBody] UpdateQuestionDto updateQuestionDto, 
        CancellationToken ct)
    {
        return  Ok("Question updated");
    }
    
    [HttpDelete("{questionId:guid}")]
    public async Task<IActionResult> Delete([FromRoute] Guid questionId, CancellationToken ct)
    {
        return  Ok("Question deleted");
    }

    [HttpPut("{questionId:guid}/best_answer")]
    public async Task<IActionResult> SetBestAnswer(
        [FromRoute] Guid questionId, 
        [FromQuery] Guid bestAnswerId, 
        CancellationToken ct)
    {
        return Ok("BestAnswer updated");
    }

    [HttpPost("{questionId:guid}/answers")]
    public async Task<IActionResult> AddAnswer(
        [FromRoute] Guid questionId, 
        [FromBody] AddAnswerDto addAnswerDto, 
        CancellationToken ct)
    {
        return Ok("Answer added");
    }
}