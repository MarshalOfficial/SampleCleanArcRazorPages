namespace Domain.Common
{
    public class BaseEntity
    {
        public int Id { get; set; }

        public DateTime CreateDate { get; set; } = DateTime.UtcNow;
        public int? CreateBy { get; set; }

        public DateTime? ModifiedDate { get; set; }
        public int? ModifiedBy { get; set; }
    }
}