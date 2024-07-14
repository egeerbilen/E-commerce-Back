using Core.Model;

namespace Entity.Model
{
    public class OrderProduct : BaseEntity
    {
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int NumberOfProducts { get; set; }
    }
}
