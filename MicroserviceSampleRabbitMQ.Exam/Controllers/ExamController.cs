using MicroserviceSampleRabbitMQ.Exam.DTOs;
using MicroserviceSampleRabbitMQ.Exam.Services;
using Microsoft.AspNetCore.Mvc;

namespace MicroserviceSampleRabbitMQ.Exam.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ExamController(IExamService examService) : ControllerBase
{
    private readonly IExamService _examService = examService;

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok(await _examService.GetAllAsync());
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> Get(Guid id)
    {
        return Ok(await _examService.GetByIdAsync(id));
    }


    [HttpPost]
    public async Task<IActionResult> Post([FromBody] ExamDto examDto)
    {
        var result = await _examService.AddAsync(examDto);
        if (result is null)
            return BadRequest();

        return Created(nameof(Get), result);
    }


    [HttpPut]
    public async Task<IActionResult> Put([FromBody] ExamDto examDto)
    {
        return Ok(_examService.UpdateAsync(examDto));
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        return Ok(_examService.DeleteAsync(id));
    }
}
