﻿using System.ComponentModel.DataAnnotations;

namespace EvidencePojisteni.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Email musí být vyplněn!")]
        [EmailAddress(ErrorMessage = "Neplatná emailová adresa")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Heslo musí být vyplněno!")]  //dořešit ještě dostatečnou sílu hesla
        [StringLength(100, ErrorMessage = "{0} musí mít délku alespoň {2} a nejvíc {1} znaků.", MinimumLength = 6)]
        [RegularExpression("^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])(?=.*[a-zA-Z])(?=.*[^a-zA-Z0-9]).{5,}$", ErrorMessage ="Heslo musí obsahovat alespoň jeden speciální znak, alespoň jedno číslo a alespoň jedno velké a jedno malé písmeno")]
        [DataType(DataType.Password)] //heslo musí obsahovat aspoň jedno číslo
        [Display(Name = "Heslo")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Potvrzení hesla musí být vyplněno!")]
        [DataType(DataType.Password)]
        [Display(Name = "Potvrzení hesla")]
        [Compare("Password", ErrorMessage = "Zadaná hesla se musí shodovat!")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Jméno musí být vyplněno!")]
        [Display(Name = "Jméno")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Příjmení musí být vyplněno!")]
        [Display(Name = "Příjmení")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Rodné číslo musí být vyplněno!")]
        [Display(Name = " Rodné číslo (bez lomítka)")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Rodné číslo musí obsahovat pouze číslice!")]
        [StringLength(10, ErrorMessage = "Rodné číslo musí obsahovat 9, případně 10 číslic!", MinimumLength = 9)]
        public string IdNumber { get; set; }
    }
}
