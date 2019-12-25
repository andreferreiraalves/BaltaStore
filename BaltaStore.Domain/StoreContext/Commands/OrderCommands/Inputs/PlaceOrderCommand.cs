using System;
using System.Collections.Generic;
using BaltaStore.Shared.Commands;
using FluentValidator;
using FluentValidator.Validation;

namespace BaltaStore.Domain.StoreContext.Commands.OrderCommands.Inputs
{
    public class PlaceOrderCommand : Notifiable, ICommand
    {
        public PlaceOrderCommand()
        {
            OrderItems = new List<OrderItem>();
        }

        public Guid Customer { get; set; }
        // public Dictionary<Guid, decimal> OrderItems { get; set; }
        public IList<OrderItem> OrderItems { get; set; }

        public bool Valid()
        {
            AddNotifications(new ValidationContract()
                .Requires()
                .HasLen(Customer.ToString(), 36, "Customer", "Identificador do cliente inválido")
                .IsGreaterThan(OrderItems.Count, 0, "OrderItems", "Nenhum item do pedido foi encontrador")
            );

            return IsValid;
        }
    }

    public class OrderItem
    {
        public Guid Product { get; set; }
        public decimal Quantity { get; set; }
    }
}