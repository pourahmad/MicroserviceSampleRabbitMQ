using RabbitMQ.Client;
using System.Text;

namespace MicroserviceSampleRabbitMQ.Exam.Services;

public class RabbitMQService : IRabbitMQService
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IModel _rabbitMQChannel;
    public RabbitMQService(IHttpClientFactory httpClientFactory, IConnection rabbiMQConnection)
    {
        _httpClientFactory = httpClientFactory;
        _rabbitMQChannel = rabbiMQConnection.CreateModel();
        _rabbitMQChannel.QueueDeclare(queue: "newExam", durable: true, exclusive: false, autoDelete: false, arguments: null);
    }
    public void SendMessage(string key, string message)
    {
        try
        {
            var body = Encoding.UTF8.GetBytes(message);
            _rabbitMQChannel.BasicPublish(exchange: "", routingKey: key, basicProperties: null, body: body);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
