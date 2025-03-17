namespace ECommerce.Domain.Entities
{
    public class Order :Entity
    {
        public int CustomerId { get; set; }
        public User Customer { get; set; } = null!;

        public DateTime OrderDate { get; set; } = DateTime.UtcNow;
        public decimal TotalAmount { get; set; }

        public List<OrderItem> Items { get; set;} = new List<OrderItem>();


    }
}
