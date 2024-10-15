using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace MicroserviceSampleRabbitMQ.Exam.Data;

public class ExamContext : DbContext
{
    public ExamContext(DbContextOptions<ExamContext> options) : base(options)
    {
        try
        {
            var database = Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator;
            if (database != null)
            {
                if (!database.CanConnect()) database.Create();
                if (!database.HasTables()) database.CreateTables();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    public DbSet<Entities.Exam> Exams { get; set; }
}
