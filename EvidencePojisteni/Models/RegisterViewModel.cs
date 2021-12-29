﻿using System.ComponentModel.DataAnnotations;

namespace EvidencePojisteni.Models
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress(ErrorMessage = "Neplatná emailová adresa")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "{0} musí mít délku alespoň {2} a nejvíc {1} znaků.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Heslo")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Potvrzení hesla")]
        [Compare("Password", ErrorMessage = "Zadaná hesla se musí shodovat.")]
        public string ConfirmPassword { get; set; }
        [Required]
        [Display(Name = "Jméno")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Příjmení")]
        public string LastName { get; set; }
        [Required]
        [Display(Name = " Rodné číslo (bez lomítka)")]
        //[RegularExpression] doplnit, aby byl splněn formát jen čísla bez lomítka
        public string IdNumber { get; set; }
    }
}
