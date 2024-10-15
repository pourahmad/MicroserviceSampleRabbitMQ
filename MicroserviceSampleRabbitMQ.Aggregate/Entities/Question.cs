namespace MicroserviceSampleRabbitMQ.Aggregate.Entities;

public class Question
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string? DefaultValue { get; set; }
    public string? Description { get; set; }
    public bool? IsPublish { get; set; }
}
