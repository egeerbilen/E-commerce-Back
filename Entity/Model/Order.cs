

using Core.Model;

namespace Entity.Model 
{
    public class Order : BaseEntity
    {
        public ICollection<OrderProduct> OrderProducts { get; set; }
    }
}
