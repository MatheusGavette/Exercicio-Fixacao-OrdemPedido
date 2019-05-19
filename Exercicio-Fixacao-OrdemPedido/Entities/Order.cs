using Exercicio_Fixacao_OrdemPedido.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exercicio_Fixacao_OrdemPedido.Entities
{
    class Order
    {
        public DateTime Moment { get; set; }
        public OrderStatus Status { get; set; }
        public List<OrderItem> Items { get; set; }
        public Client Client { get; set; }

        public Order()
        {

        }
        public Order(DateTime moment, OrderStatus status)
        {
            Moment = moment;
            Status = status;
        }

        public void AddItem(OrderItem item)
        {
            Items.Add(item);
        }

        public void RemoveItem(OrderItem item)
        {
            Items.Remove(item);
        }

        public double Total()
        {
            double valorTotal = 0;

            foreach (OrderItem item in Items)
            {
                valorTotal += item.SubTotal();
            }

            return valorTotal;
        }

        public override string ToString()
        {
            StringBuilder extrato = new StringBuilder();
            extrato.AppendLine("Order Sumary:");
            extrato.AppendLine($"Order Moment: {Moment.ToString("dd/MM/yyyy HH:mm:ss")}");
            extrato.AppendLine($"Order Status: {Status.ToString()}");
            extrato.Append($"Cliente: {Client.Name}");
            extrato.Append($" ({Client.BirthDate})");
            extrato.Append(" - ");
            extrato.AppendLine(Client.Email);
            extrato.AppendLine("Order Items:");
            foreach (OrderItem item in Items)
            {
                extrato.Append(item.Product.Name);
                extrato.Append($", ${item.Price}");
                extrato.Append($", Quantity: {item.Quantity}");
                extrato.Append($", Subtotal: {item.SubTotal().ToString()}");
            }
            extrato.Append($"Total Price: {Total().ToString()}");

            return extrato.ToString();

        }
    }
}
