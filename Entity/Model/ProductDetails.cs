using Core.Model;

namespace Entity.Model
{
    public class ProductDetails : BaseEntity
    {
        public string? Description { get; set; }
        public int Stock { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
