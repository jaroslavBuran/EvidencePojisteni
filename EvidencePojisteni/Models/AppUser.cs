using EvidencePojisteni.Models.Products;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace EvidencePojisteni.Models
{
    public class AppUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IdNumber { get; set; }
        

        [InverseProperty(nameof(Product.User))]
        public ICollection<Product> Products { get; set; }
    }
}
