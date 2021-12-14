using System.ComponentModel.DataAnnotations;

namespace EvidencePojisteni.Models
{
    public class TestModel
    {
        [Key]
        public int TestId { get; set; }
        public string Name { get; set; }
    }
}
