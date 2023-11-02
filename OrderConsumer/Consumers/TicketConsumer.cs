using MassTransit;
using Shared.Model;

namespace OrderConsumer.Consumers
{
    public class TicketConsumer : IConsumer<Ticket>
    {
        private readonly ILogger<TicketConsumer> _logger;
        private static int _counter = 0;
        public TicketConsumer(ILogger<TicketConsumer> logger)
        {
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<Ticket> context)
        {
            await Console.Out.WriteLineAsync($"Ticket received: {context.Message.UserName}");
            _logger.LogInformation("({Id}) Ticket consumed: {UserName} - {Location}", ++_counter, context.Message.UserName, context.Message.Location);
        }
    }
}