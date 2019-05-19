using Exercicio_Fixacao_OrdemPedido.Entities;
using Exercicio_Fixacao_OrdemPedido.Entities.Enum;
using System.Globalization;
using System;

namespace Exercicio_Fixacao_OrdemPedido
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Client Data: ");

            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Email: ");
            string email = Console.ReadLine();
            Console.Write("Birth date (DD/MM/YYYY): ");
            DateTime dateBirth = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("\n -------------------- \n");

            Client client = new Client(name, email, dateBirth);
            
            Order orderClient = new Order(DateTime.Now, Enum.Parse<OrderStatus>("Processing"), client);

            Console.Write("How many items to this order? ");
            int qtd = int.Parse(Console.ReadLine());

            Console.WriteLine("\n -------------------- \n");

            for (int i = 0; i < qtd; i++)
            {
                Console.WriteLine("Enter product {0}", i+1);
                Console.Write("Product Name: ");
                string nameProd = Console.ReadLine();
                Console.Write("Price: ");
                double price = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Quantity: ");
                int qtdProd = int.Parse(Console.ReadLine());

                Product prod = new Product(nameProd, price);
                OrderItem newItem = new OrderItem(qtdProd, prod, price);

                orderClient.AddItem(newItem);

                Console.WriteLine("\n -------------------- \n");
            }

            Console.WriteLine(orderClient);
            Console.ReadLine();
        }
    }
}
