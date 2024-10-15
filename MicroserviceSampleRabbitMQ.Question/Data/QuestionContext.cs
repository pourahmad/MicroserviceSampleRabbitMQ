using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace MicroserviceSampleRabbitMQ.Question.Data;

public class QuestionContext : DbContext
{
    public QuestionContext(DbContextOptions<QuestionContext> options) : base(options)
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

    public DbSet<Entities.Question> Questions { get; set; }
}