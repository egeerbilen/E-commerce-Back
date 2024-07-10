namespace Entity.Interface
{
    public interface IBaseEntity
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; } // eklendiği esnada null olacağı için ? koyduk
        public bool IsDeleted { get; set; } // eklendiği esnada null olacağı için ? koyduk
    }
}
