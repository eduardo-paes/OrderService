using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Shared.Model;

namespace OrderProducer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IBus _bus;
        public OrderController(IBus bus)
        {
            _bus = bus;
        }

        [HttpPost]
        public async Task<IActionResult> CreateTicket(Ticket ticket)
        {
            if (ticket == null)
                return BadRequest("Ticket is null.");

            ticket.Booked = DateTime.Now;
            var uri = new Uri("rabbitmq://localhost/order-queue");
            var endpoint = await _bus.GetSendEndpoint(uri);
            await endpoint.Send(ticket);
            return Ok("Ticket is booked.");
        }
    }
}