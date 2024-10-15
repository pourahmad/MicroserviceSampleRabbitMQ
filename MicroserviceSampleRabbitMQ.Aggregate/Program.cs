using MicroserviceSampleRabbitMQ.Aggregate.Data;
using MicroserviceSampleRabbitMQ.Aggregate.Services;
using Microsoft.EntityFrameworkCore;
using RabbitMQ.Client;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string MongoDbConnectionString = Environment.GetEnvironmentVariable("MongoDbConnectionString");
string MongoDbName = Environment.GetEnvironmentVariable("MongoDbName");
builder.Services.AddDbContext<AggregateDbContext>(option =>
    option.UseMongoDB(MongoDbConnectionString, MongoDbName));

builder.Services.AddSingleton(sp =>
{
    string rabbitMQHost = Environment.GetEnvironmentVariable("RABBITMQ_HOST");

    var factory = new ConnectionFactory()
    {
        HostName = rabbitMQHost??"localhost",
        UserName = "guest",
        Password = "guest",
    };
    return factory.CreateConnection();
});


builder.Services.AddHostedService<AnswerReseiver>();
builder.Services.AddScoped<IExamService, ExamService>();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseAuthorization();

app.MapControllers();

app.Run();
