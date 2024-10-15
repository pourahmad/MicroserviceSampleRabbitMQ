namespace MicroserviceSampleRabbitMQ.Aggregate.Enities;

public class ExamDto
{
    public Guid Id { get; set; }
    public string Answer { get; set; }
    public Guid StudentId { get; set; }
    public Guid QusetionId { get; set; }
    public bool IsAccept { get; set; }
}