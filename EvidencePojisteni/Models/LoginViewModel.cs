using System.ComponentModel.DataAnnotations;

namespace EvidencePojisteni.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Email musí být vyplněn!")]
        [EmailAddress(ErrorMessage = "Neplatná emailová adresa!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Heslo musí být vyplněno!")]
        [DataType(DataType.Password)]
        [Display(Name = "Heslo")]
        public string Password { get; set; }

        [Display(Name = "Pamatuj si mě")]
        public bool RememberMe { get; set; }
    }
}
