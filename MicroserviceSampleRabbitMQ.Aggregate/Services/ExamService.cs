using MicroserviceSampleRabbitMQ.Aggregate.Data;
using MicroserviceSampleRabbitMQ.Aggregate.Enities;
using Microsoft.EntityFrameworkCore;

namespace MicroserviceSampleRabbitMQ.Aggregate.Services;

public class ExamService(AggregateDbContext context) : IExamService
{
    private readonly AggregateDbContext _context = context;
    public async Task<IList<Entities.Exam>> GetAllAsync()
    {
        try
        {
            var result = await _context.Exams.ToListAsync();
            return result;
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

            return exam;
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
