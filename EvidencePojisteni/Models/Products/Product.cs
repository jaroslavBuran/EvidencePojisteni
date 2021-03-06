using EvidencePojisteni.Models.InsuranceEvents;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EvidencePojisteni.Models.Products
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Title { get; set; }
        public string ShortDesc { get; set; }
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        public string UserId { get; set; }
       
        [InverseProperty("Products")]
        public virtual AppUser User { get; set; }

        [InverseProperty(nameof(InsuranceEvent.Product))]
        public ICollection<InsuranceEvent> Events { get; set; }



    }
}
