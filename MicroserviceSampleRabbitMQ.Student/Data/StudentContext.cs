using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace MicroserviceSampleRabbitMQ.Student.Data;

public class StudentContext: DbContext
{
    public StudentContext(DbContextOptions<StudentContext> options): base(options)
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

    public DbSet<Entities.Student> Students { get; set; }
}
