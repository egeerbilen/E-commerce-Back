

using Core.Model;

namespace Entity.Model 
{
    public class Order : BaseEntity
    {
        public int UserId { get; set; }
        public int TotalOrders { get; set; }
        public int CustomerId { get; set; }
        public User User { get; set; }
        public ICollection<OrderProduct> OrderProducts { get; set; }
    }
}
