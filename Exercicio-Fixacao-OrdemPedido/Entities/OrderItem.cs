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

        public double SubTotal()
        {
            

            return Quantity * Price;

        }
    }
}
