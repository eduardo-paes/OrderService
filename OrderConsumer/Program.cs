using MassTransit;
using OrderConsumer.Consumers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMassTransit(x =>
{
    x.AddConsumer<TicketConsumer>();
    x.UsingRabbitMq((context, cfg) =>
   {
       cfg.Host(new Uri("rabbitmq://localhost"), h =>
       {
           h.Username("guest");
           h.Password("guest");
       });

       cfg.ReceiveEndpoint("order-queue", ep =>
        {
            ep.PrefetchCount = 10;
            ep.UseMessageRetry(r => r.Interval(2, 100));
            ep.ConfigureConsumer<TicketConsumer>(context);
        });
   });
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
