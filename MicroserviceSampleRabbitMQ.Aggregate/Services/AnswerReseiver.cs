using MicroserviceSampleRabbitMQ.Aggregate.Enities;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace MicroserviceSampleRabbitMQ.Aggregate.Services;

public class AnswerReseiver : BackgroundService
{
    private readonly IModel _rabbitMQchannel;
    private readonly IServiceProvider _serviceProvider;

    public AnswerReseiver(IConnection rabbitMQConnection, IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
        _rabbitMQchannel = rabbitMQConnection.CreateModel();
        _rabbitMQchannel
            .QueueDeclare(queue: "newExam", 
            durable: true, 
            exclusive: false, 
            autoDelete: false, 
            arguments: null);        
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        try
        {
            var consumer = new EventingBasicConsumer(_rabbitMQchannel);
            consumer.Received += async (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                var response = Newtonsoft.Json.JsonConvert.DeserializeObject<ExamDto>(message);

                using (var scope = _serviceProvider.CreateScope())
                {
                    var examService = scope.ServiceProvider.GetRequiredService<IExamService>();
                   await examService.AddAsync(response);
                }
            };

            _rabbitMQchannel
                .BasicConsume(queue: "newExam",
                autoAck: true,
                consumer: consumer);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
    }
}
