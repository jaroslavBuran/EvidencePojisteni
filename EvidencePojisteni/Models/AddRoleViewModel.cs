using System.ComponentModel.DataAnnotations;

namespace EvidencePojisteni.Models
{
    public class AddRoleViewModel
    {
        [Required]
        public string RoleName { get; set; }
    }
}
