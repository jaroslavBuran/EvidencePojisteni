using System.ComponentModel.DataAnnotations;

namespace EvidencePojisteni.Models.Products
{
    public class ProductDetailViewModel
    {
        public int ProductId { get; set; }
        public string Title { get; set; }
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        public string UserId { get; set; }
    }
}
