using System;
using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;

namespace _2._1.OrdersSystem
{
    public class OrdersSystem
    {
        static void Main(string[] args)
        {
            Dictionary<string, BigList<Order>> consumers = new Dictionary<string, BigList<Order>>();
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
                        if (!consumers.ContainsKey(consumer))
                        {
                            consumers.Add(consumer, new BigList<Order>() { newOrder });
                        }
                        else
                        {
                            consumers[consumer].Add(newOrder);
                        }

                        Console.WriteLine("Order added");
                        break;

                    case "DeleteOrders":
                        string consumerToDelete = commandLine.Substring(command.Length + 1);
                        if (consumers.ContainsKey(consumerToDelete))
                        {
                            int ordersCount = consumers[consumerToDelete].Count;
                            consumers.Remove(consumerToDelete);
                            Console.WriteLine(ordersCount + " orders deleted");
                        }
                        else
                        {
                            Console.WriteLine("No orders found");
                        }
                        break;

                    case "FindOrdersByPriceRange":
                        string[] priceRanges = commandLine.Substring(command.Length + 1).Split(';');
                        decimal fromPrice = decimal.Parse(priceRanges[0]);
                        decimal toPrice = decimal.Parse(priceRanges[1]);

                        List<Order> ordersByPrice = new List<Order>();


                        consumers
                            .ToList()
                            .ForEach(list => list.Value
                                                 .ForEach(o =>
                                                 {
                                                     if (o.Price >= fromPrice && o.Price <= toPrice)
                                                     {
                                                         ordersByPrice.Add(o);
                                                     }
                                                 }));

                        if (ordersByPrice.Count() > 0)
                        {
                            Console.WriteLine(string.Join("\n", ordersByPrice.OrderBy(o => o.Name)));
                        }
                        else
                        {
                            Console.WriteLine("No orders found");
                        }
                        break;

                    case "FindOrdersByConsumer":
                        string consumerToFind = commandLine.Substring(command.Length + 1);
                        if (consumers.ContainsKey(consumerToFind))
                        {
                            var ordersByConsumer = consumers[consumerToFind].OrderBy(o => o.Name);
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
            int result = this.Name.CompareTo(other.Name);
            if (result == 0)
            {
                result = this.Price.CompareTo(other.Price);
            }

            return result;
        }

        public override string ToString()
        {
            return "{" + this.Name + ";" + this.Consumer + ";" + string.Format("{0:0.00}", this.Price) + "}";
        }
    }
}
