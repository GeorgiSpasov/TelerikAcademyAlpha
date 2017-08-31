using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._1.OrdersSystem
{
    public class OrdersSystem
    {
        static void Main(string[] args)
        {
            List<Order> orders = new List<Order>();
            int n = int.Parse(Console.ReadLine());
            string commandLine;
            string command;
            string[] commandParams;

            for (int i = 0; i < n; i++)
            {
                commandLine = Console.ReadLine();
                command = commandLine.Split(' ')[0];
                switch (command)
                {
                    case "AddOrder":
                        commandParams = commandLine.Substring(command.Length + 1).Split(';');
                        string name = commandParams[0];
                        decimal price = decimal.Parse(commandParams[1]);
                        string consumer = commandParams[2];
                        Order newOrder = new Order(name, price, consumer);
                        orders.Add(newOrder);

                        Console.WriteLine("Order added");
                        break;
                    case "DeleteOrders":
                        string consumerToDelete = commandLine.Substring(command.Length + 1);
                        int ordersCount = orders.Where(o => o.Consumer == consumerToDelete).Count();
                        if (ordersCount > 0)
                        {
                            orders.RemoveAll(o => o.Consumer == consumerToDelete);
                            Console.WriteLine(ordersCount + " orders deleted");
                        }
                        else
                        {
                            Console.WriteLine("No orders found");
                        }
                        break;
                    case "FindOrdersByPriceRange":
                        decimal[] priceRanges = commandLine.Substring(command.Length + 1).Split(';').Select(p => decimal.Parse(p)).ToArray();
                        decimal fromPrice = priceRanges[0];
                        decimal toPrice = priceRanges[1];
                        var ordersByPrice = orders.Where(o => o.Price >= fromPrice && o.Price <= toPrice).OrderBy(o => o.Name);
                        if (ordersByPrice.Count() > 0)
                        {
                            Console.WriteLine(string.Join("\n", ordersByPrice));
                        }
                        else
                        {
                            Console.WriteLine("No orders found");
                        }
                        break;
                    case "FindOrdersByConsumer":
                        string consumerToFind = commandLine.Substring(command.Length + 1);
                        var ordersByConsumer = orders.Where(o => o.Consumer == consumerToFind).OrderBy(o => o.Name);
                        if (ordersByConsumer.Count() > 0)
                        {
                            Console.WriteLine(string.Join("\n", ordersByConsumer));
                        }
                        else
                        {
                            Console.WriteLine("No orders found");
                        }
                        break;
                    default:
                        break;
                }
            }
        }
    }

    public class Order : IComparable<Order>
    {
        public Order(string name, decimal price, string consumer)
        {
            this.Name = name;
            this.Price = price;
            this.Consumer = consumer;
        }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Consumer { get; set; }

        public int CompareTo(Order other)
        {
            int result = this.Price.CompareTo(other.Price);
            if (result == 0)
            {
                result = this.Name.CompareTo(other.Name);
            }

            return result;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append("{");
            result.AppendFormat("{0};{1};{2:0.00}", this.Name, this.Consumer, this.Price);
            result.Append("}");

            return result.ToString();
        }
    }
}
