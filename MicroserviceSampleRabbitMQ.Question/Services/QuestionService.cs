using MicroserviceSampleRabbitMQ.Question.Data;
using MicroserviceSampleRabbitMQ.Question.DTOs;
using Microsoft.EntityFrameworkCore;

namespace MicroserviceSampleRabbitMQ.Question.Services;

public class QuestionService(QuestionContext context) : IQuestionService
{
    private readonly QuestionContext _context = context;
    public async Task<IList<Entities.Question>> GetAllAsync()
    {
        try
        {
            return await _context.Questions.ToListAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            throw;
        }
    }

    public async Task<Entities.Question> GetByIdAsync(Guid id)
    {
        try
        {
            return await _context.Questions.FindAsync(id) ?? new Entities.Question();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            throw;
        }
    }

    public async Task<object> AddAsync(QuestionDto questionDto)
    {
        try
        {
            Entities.Question question = new Entities.Question();
            question.Title = questionDto.Title;
            question.Description = questionDto.Description;
            question.DefaultValue = questionDto.DefaultValue;
            question.IsPublish = questionDto.IsPublish;

            await _context.Questions.AddAsync(question);
            await _context.SaveChangesAsync();

            return question.Id;
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

    public async Task UpdateAsync(QuestionDto questionDto)
    {
        throw new NotImplementedException();
    }
}
