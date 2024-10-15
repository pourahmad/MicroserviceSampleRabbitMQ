namespace MicroserviceSampleRabbitMQ.Exam.Services;

public interface IRabbitMQService
{
    void SendMessage(string key, string message);
}
