using MicroserviceSampleRabbitMQ.Question.DTOs;

namespace MicroserviceSampleRabbitMQ.Question.Services;

public interface IQuestionService
{
    Task<IList<Entities.Question>> GetAllAsync();
    Task<Entities.Question> GetByIdAsync(Guid id);
    Task<object> AddAsync(QuestionDto questionDto);
    Task UpdateAsync(QuestionDto questionDto);
    Task DeleteAsync(Guid id);
}
