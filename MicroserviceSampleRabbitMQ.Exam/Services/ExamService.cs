using MicroserviceSampleRabbitMQ.Exam.Data;
using MicroserviceSampleRabbitMQ.Exam.DTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.Json;
using Newtonsoft.Json;

namespace MicroserviceSampleRabbitMQ.Exam.Services;

public  class ExamService(ExamContext context, IRabbitMQService rabbitMQService) : IExamService
{
    private readonly ExamContext _context = context;
    private readonly IRabbitMQService _rabbitMQService = rabbitMQService;
    public async Task<IList<Entities.Exam>> GetAllAsync()
    {
        try
        {
            return await _context.Exams.ToListAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            throw;
        }
    }

    public async Task<Entities.Exam> GetByIdAsync(Guid id)
    {
        try
        {
            return await _context.Exams.FindAsync(id) ?? new Entities.Exam();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            throw;
        }
    }

    public async Task<object> AddAsync(ExamDto examDto)
    {
        try
        {
            Entities.Exam exam = new Entities.Exam();
            exam.Answer = examDto.Answer;
            exam.StudentId = examDto.StudentId;
            exam.QusetionId = examDto.QusetionId;

            await _context.Exams.AddAsync(exam);
            await _context.SaveChangesAsync();

            _rabbitMQService.SendMessage("newExam", JsonConvert.SerializeObject(exam));

            return exam.Id;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            throw;
        }
    }

    public async Task DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task UpdateAsync(ExamDto examDto)
    {
        throw new NotImplementedException();
    }
}
