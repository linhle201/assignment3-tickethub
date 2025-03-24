using System.ComponentModel.DataAnnotations;

namespace assignment3_tickethub
{
    public class TicketHub
    {

        [Required]
        public int ConcertId = 0;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Name { get; set; } = string.Empty;

        [Phone]
        public string Phone { get; set; } = string.Empty;

        
        public int Quantity = 0; 

        [Required]
        public string CreditCard { get; set; } = string.Empty;

        [Required]
        public string Expiration { get; set; } = string.Empty;

        [Required]
        public string SecurityCode { get; set; } = string.Empty;

        [Required]
        public string Address { get; set; } = string.Empty;

        [Required]
        public string City { get; set; } = string.Empty;

        [Required]
        public string Province { get; set; } = string.Empty;

        [Required]
        public string PostalCode { get; set; } = string.Empty;

        [Required]
        public string Country { get; set; } = string.Empty;
    }
}
