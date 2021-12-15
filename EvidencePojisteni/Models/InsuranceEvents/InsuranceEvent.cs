using EvidencePojisteni.Models.Products;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EvidencePojisteni.Models.InsuranceEvents
{
    public class InsuranceEvent
    {
        [Key]
        public int EventId { get; set; }
        public string EventName { get; set; }
        public string EventDescription { get; set; }
        public string SelectedItem { get; set; }


        [InverseProperty("Events")]
        public virtual Product Product { get; set; }
    }
}
