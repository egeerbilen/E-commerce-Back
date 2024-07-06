using Core.DTOs;
using Core.Model;

namespace Entity.DTOs
{
    public class ProductDetailsDto : BaseEntity
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public int Stock { get; set; }
        public int ProductId { get; set; }
    }
}
