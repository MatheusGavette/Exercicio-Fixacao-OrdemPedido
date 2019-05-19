using Exercicio_Fixacao_OrdemPedido.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Exercicio_Fixacao_OrdemPedido.Entities
{
    class Order
    {
        public DateTime Moment { get; set; }
        public OrderStatus Status { get; set; }
        public List<OrderItem> Items { get; set; } = new List<OrderItem>();
        public Client Client { get; set; }

        public Order()
        {

        }
        public Order(DateTime moment, OrderStatus status, Client client)
        {
            Moment = moment;
            Status = status;
            Client = client;
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
            extrato.AppendLine($"Order Moment: {Moment.ToString("dd/MM/yyyy")}");
            extrato.AppendLine($"Order Status: {Status.ToString()}");
            extrato.Append($"Cliente: {Client.Name}");
            extrato.Append($" ({Client.BirthDate.ToString("dd/MM/yyyy")})");
            extrato.Append(" - ");
            extrato.AppendLine(Client.Email);
            extrato.AppendLine("Order Items:");
            foreach (OrderItem item in Items)
            {
                extrato.Append(item.Product.Name);
                extrato.Append($", ${item.Price.ToString("F2", CultureInfo.InvariantCulture)}");
                extrato.Append($", Quantity: {item.Quantity}");
                extrato.AppendLine($", Subtotal: {item.SubTotal().ToString("F2", CultureInfo.InvariantCulture)}");
            }
            extrato.Append($"Total Price: {Total().ToString("F2", CultureInfo.InvariantCulture)}");

            return extrato.ToString();

        }
    }
}
