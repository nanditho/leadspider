using System.ComponentModel.DataAnnotations;

namespace LeadSpider.Models
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}