namespace MicroserviceSampleRabbitMQ.Aggregate.Entities;

public class Student
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public string Phone { get; set; }
}