using MicroserviceSampleRabbitMQ.Exam.DTOs;

namespace MicroserviceSampleRabbitMQ.Exam.Services;

public interface IExamService
{
    Task<IList<Entities.Exam>> GetAllAsync();
    Task<Entities.Exam> GetByIdAsync(Guid id);
    Task<object> AddAsync(ExamDto examDto);
    Task UpdateAsync(ExamDto examDto);
    Task DeleteAsync(Guid id);
}