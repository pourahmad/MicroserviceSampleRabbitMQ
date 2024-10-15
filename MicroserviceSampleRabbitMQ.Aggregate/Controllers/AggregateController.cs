using MicroserviceSampleRabbitMQ.Aggregate.Services;
using Microsoft.AspNetCore.Mvc;

namespace MicroserviceSampleRabbitMQ.Aggregate.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AggregateController(IExamService examService) : ControllerBase
{
    private readonly IExamService _examService = examService;
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok(await _examService.GetAllAsync());
    }
}
