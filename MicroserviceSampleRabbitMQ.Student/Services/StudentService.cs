using MicroserviceSampleRabbitMQ.Student.Data;
using MicroserviceSampleRabbitMQ.Student.DTOs;
using Microsoft.EntityFrameworkCore;

namespace MicroserviceSampleRabbitMQ.Student.Services;

public class StudentService(StudentContext context) : IStudentService
{
    private readonly StudentContext _context = context;
    public async Task<IList<Entities.Student>> GetAllAsync()
    {
        try
        {
            return await _context.Students.ToListAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            throw;
        }
    }

    public async Task<Entities.Student> GetByIdAsync(Guid id)
    {
        try
        {
            return await _context.Students.FindAsync(id)??new Entities.Student();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            throw;
        }
    }

    public async Task<object> AddAsync(StudentDto studentDto)
    {
        try
        {
            Entities.Student student = new Entities.Student();
            student.Name = studentDto.Name;
            student.Address = studentDto.Address;
            student.Phone = studentDto.Phone;

            await _context.Students.AddAsync(student);
            await _context.SaveChangesAsync();

            return student.Id;
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

    public async Task UpdateAsync(StudentDto studentDto)
    {
        throw new NotImplementedException();
    }
}