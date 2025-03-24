using Azure.Storage.Queues;
using System.Runtime.InteropServices.Marshalling;
using System.Text.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace assignment3_tickethub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketHubController : ControllerBase
    {
        private readonly ILogger<TicketHubController> _logger;
        private readonly IConfiguration _configuration;

        public TicketHubController(ILogger<TicketHubController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Hello from TicketHub!");
        }

        [HttpPost]
        public async Task<IActionResult> Post(TicketHub tickethub)
        {
            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }
            string queueName = "tickethub";
            string? connectionString = _configuration["AzureStorageConnectionString"];
            QueueClient queueClient = new QueueClient(connectionString, queueName);

            // serialize an object to json
            string message = JsonSerializer.Serialize(tickethub);

            // send string message to queue
            await queueClient.SendMessageAsync(message);

            return Ok("Success- message posted to Storge Queue");
        }

    }
}
