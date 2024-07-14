

using Core.Model;

namespace Entity.Model 
{
    public class Order : BaseEntity
    {
        public int TotalOrders { get; set; }
        public int TotalPrice { get; set; }
        public int CustomerId { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public ICollection<OrderProduct> OrderProducts { get; set; }
    }
}
