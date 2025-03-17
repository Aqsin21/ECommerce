﻿namespace ECommerce.Domain.Entities
{
    public  class OrderItem:Entity
    {
        public int OrderId { get; set; }
        public Order Order { get; set; } = null!;

        public int ProductId { get; set; }
        public Product Product { get; set; } = null!;

        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }


        public decimal TotalePrice => Quantity * TotalePrice;



    }
}
