using System.ComponentModel.DataAnnotations;

namespace EvidencePojisteni.Models
{
    public class EditViewModel
    {
        public string Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public string IdNumber { get; set; }
    }
}
