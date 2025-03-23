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
        public IActionResult Post(TicketHub ticketHub)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);  
            }

            // Additional custom validation (if necessary)
            if (ticketHub.ConcertId <= 0)
            {
                return BadRequest("Concert Id is invalid.");
            }
            if (string.IsNullOrEmpty(ticketHub.Email))
            {
                return BadRequest("Email is invalid.");
            }
            if (string.IsNullOrEmpty(ticketHub.Name))
            {
                return BadRequest("Name is invalid.");
            }
            if (ticketHub.Quantity <= 0)
            {
                return BadRequest("Quantity must be greater than 0.");
            }

            // Check if CreditCard is valid
            if (string.IsNullOrEmpty(ticketHub.CreditCard) || ticketHub.CreditCard.Length != 16)
            {
                return BadRequest("Credit Card number must be 16 digits.");
            }

            if (string.IsNullOrEmpty(ticketHub.Expiration) || !System.Text.RegularExpressions.Regex.IsMatch(ticketHub.Expiration, @"^(0[1-9]|1[0-2])\/(\d{2})$"))
            {
                return BadRequest("Expiration date must be in MM/YY format.");
            }

            if (string.IsNullOrEmpty(ticketHub.SecurityCode) || ticketHub.SecurityCode.Length != 3)
            {
                return BadRequest("Security Code must be 3 digits.");
            }

            if (string.IsNullOrEmpty(ticketHub.Address))
            {
                return BadRequest("Address is required.");
            }
            if (string.IsNullOrEmpty(ticketHub.City))
            {
                return BadRequest("City is required.");
            }
            if (string.IsNullOrEmpty(ticketHub.Province))
            {
                return BadRequest("Province is required.");
            }
            if (string.IsNullOrEmpty(ticketHub.PostalCode))
            {
                return BadRequest("PostalCode is required.");
            }
            if (string.IsNullOrEmpty(ticketHub.Country))
            {
                return BadRequest("Country is required.");
            }

            return Ok($"Hello {ticketHub.Name}, your ticket purchase request was successfully received.");
        }
    }
}
