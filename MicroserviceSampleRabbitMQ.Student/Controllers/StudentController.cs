using MicroserviceSampleRabbitMQ.Student.DTOs;
using MicroserviceSampleRabbitMQ.Student.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MicroserviceSampleRabbitMQ.Student.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StudentController(IStudentService studentService) : ControllerBase
{
    private readonly IStudentService _studentService = studentService;

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok(await _studentService.GetAllAsync());
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> Get(Guid id)
    {
        return Ok(await _studentService.GetByIdAsync(id));
    }


    [HttpPost]
    public async Task<IActionResult> Post([FromBody] StudentDto studentDto)
    {
        return Created(nameof(Get), await _studentService.AddAsync(studentDto));
    }


    [HttpPut]
    public async Task<IActionResult> Put([FromBody] StudentDto studentDto)
    {
        return Ok(_studentService.UpdateAsync(studentDto));
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        return Ok(_studentService.DeleteAsync(id));
    }
}
