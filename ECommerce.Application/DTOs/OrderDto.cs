using System;

namespace ECommerce.Application.DTOs
{
    public class OrderDto
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; } = null!;
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public List<OrderItemDto> Items { get; set; } = new();
    }
   
         public class CreateOrderDto
    {
        public int CustomerId { get; set; }
        public List<CreateOrderItemDto> Items { get; set; } = new();
    }
   
        public class UpdateOrderDto
    {
        public int Id { get; set; }
        public List<UpdateOrderItemDto> Items { get; set; } = new();
    }
}
