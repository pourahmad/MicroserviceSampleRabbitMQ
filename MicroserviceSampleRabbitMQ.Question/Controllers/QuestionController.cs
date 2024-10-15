using MicroserviceSampleRabbitMQ.Question.DTOs;
using MicroserviceSampleRabbitMQ.Question.Services;
using Microsoft.AspNetCore.Mvc;

namespace MicroserviceSampleRabbitMQ.Question.Controllers;

[Route("api/[controller]")]
[ApiController]
public class QuestionController(IQuestionService questionService) : ControllerBase
{
    private readonly IQuestionService _questionService = questionService;

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok(await _questionService.GetAllAsync());
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> Get(Guid id)
    {
        return Ok(await _questionService.GetByIdAsync(id));
    }


    [HttpPost]
    public async Task<IActionResult> Post([FromBody] QuestionDto questionDto)
    {
        return Created(nameof(Get), await _questionService.AddAsync(questionDto));
    }


    [HttpPut]
    public async Task<IActionResult> Put([FromBody] QuestionDto questionDto)
    {
        return Ok(_questionService.UpdateAsync(questionDto));
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        return Ok(_questionService.DeleteAsync(id));
    }
}
