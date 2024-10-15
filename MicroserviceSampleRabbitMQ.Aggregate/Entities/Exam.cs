using MongoDB.Bson;

namespace MicroserviceSampleRabbitMQ.Aggregate.Entities;

public class Exam
{
    public ObjectId _id { get; set; }
    public string Answer { get; set; }
    public Guid StudentId { get; set; }
    public Guid QusetionId { get; set; }
    public bool IsAccept { get; set; }
}