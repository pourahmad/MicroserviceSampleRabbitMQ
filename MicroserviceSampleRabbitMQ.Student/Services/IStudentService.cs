using MicroserviceSampleRabbitMQ.Student.DTOs;

namespace MicroserviceSampleRabbitMQ.Student.Services;

public interface IStudentService
{
    Task<IList<Entities.Student>> GetAllAsync();
    Task<Entities.Student> GetByIdAsync(Guid id);
    Task<object> AddAsync(StudentDto studentDto);
    Task UpdateAsync(StudentDto studentDto);
    Task DeleteAsync(Guid id);
}
