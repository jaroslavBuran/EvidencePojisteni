using EvidencePojisteni.Models.Products;
using System.ComponentModel.DataAnnotations.Schema;

namespace EvidencePojisteni.Models.Events
{
    public class Event
    {
        public int EventId { get; set; }
        public string EventName { get; set; }
        public string EventDescription { get; set; }


        [InverseProperty("Events")]
        public virtual Product Product { get; set; }
    }
}
