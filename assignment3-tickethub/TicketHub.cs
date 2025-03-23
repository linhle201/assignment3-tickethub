using System.ComponentModel.DataAnnotations;

namespace assignment3_tickethub
{
    public class TicketHub
    {

        [Required]
        public int ConcertId { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Name { get; set; } = string.Empty;

        [Phone]
        public string Phone { get; set; } = string.Empty;

        [Range(1, 10)]  
        public int Quantity { get; set; } 

        [Required]
        public string CreditCard { get; set; }

        [Required]
        public string Expiration { get; set; }

        [Required]
        public string SecurityCode { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string Province { get; set; }

        [Required]
        public string PostalCode { get; set; }

        [Required]
        public string Country { get; set; }
    }
}
