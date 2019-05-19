using System.Globalization;

namespace Exercicio_Fixacao_OrdemPedido.Entities
{
    class OrderItem
    {
        public int Quantity { get; set; }
        public double Price { get; private set; }
        public Product Product { get; set; }

        public OrderItem(int quantity)
        {
            Quantity = quantity;
        }

        public OrderItem(int quantity, Product product) : this(quantity)
        {
            Product = product;
            Price = Product.Price;
        }

        public OrderItem (int quantity, Product product, double price) : this (quantity, product)
        {
            Price = price;
        }

        public double SubTotal()
        {
            

            return Quantity * Price;

        }

        public override string ToString()
        {
            return Product.Name
                + ", $"
                + Price.ToString("F2", CultureInfo.InvariantCulture)
                + ", Quantity: "
                + Quantity
                + ", Subtotal: $"
                + SubTotal().ToString("F2", CultureInfo.InvariantCulture);
        }
    }
}
