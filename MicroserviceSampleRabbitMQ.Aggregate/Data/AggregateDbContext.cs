using MicroserviceSampleRabbitMQ.Aggregate.Entities;
using Microsoft.EntityFrameworkCore;
using MongoDB.EntityFrameworkCore.Extensions;

namespace MicroserviceSampleRabbitMQ.Aggregate.Data;

public class AggregateDbContext: DbContext
{
    public AggregateDbContext(DbContextOptions<AggregateDbContext> options): base(options)
    {
        
    }
    
    public DbSet<Exam> Exams { get; set; }
    public DbSet<Question> Questions { get; set; }
    public DbSet<Student> Students { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Exam>().ToCollection("Exam");
        modelBuilder.Entity<Question>().ToCollection("Question");
        modelBuilder.Entity<Student>().ToCollection("Student");

        base.OnModelCreating(modelBuilder);
    }
}
