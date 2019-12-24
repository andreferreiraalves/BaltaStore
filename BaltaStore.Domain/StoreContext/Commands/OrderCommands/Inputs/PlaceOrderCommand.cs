using System;
using System.Collections.Generic;

namespace BaltaStore.Domain.StoreContext.Commands.OrderCommands.Inputs
{
    public class PlaceOrderCommand
    {
        public Guid Customer { get; set; }
        // public Dictionary<Guid, decimal> OrderItems { get; set; }
        public IList<OrderItem> OrderItems { get; set; }
    }

    public class OrderItem
    {
        public Guid Product { get; set; }
        public decimal Quantity { get; set; }
    }
}