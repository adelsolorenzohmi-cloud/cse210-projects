using System;
using System.Collections.Generic;

public class Program
{
    public static void Main(string[] args)
    {
        // --- Order 1: USA Customer (Shipping: $5) ---

        Address address1 = new Address("490 W 150 S", "Provo", "UT", "USA");
        Customer customer1 = new Customer("Alex Johnson", address1);

        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("Mechanical Pencil", "MP-001", 3.00m, 5));
        order1.AddProduct(new Product("Notebook (A4)", "NB-102", 5.99m, 2));

        Console.WriteLine("======================================");
        Console.WriteLine("🌎 Order 1: USA Customer (Shipping: $5)");
        Console.WriteLine("======================================");
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine("--------------------------------------");
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine("--------------------------------------");
        Console.WriteLine($"Total Order Cost: ${order1.GetTotal():0.00}\n");


        // --- Order 2: International Customer (Shipping: $35) ---

        Address address2 = new Address("88 Queen Victoria St", "London", "England", "UK");
        Customer customer2 = new Customer("Marie Dubois", address2);

        Order order2 = new Order(customer2);
        order2.AddProduct(new Product("Monitor 4K", "MN-5000", 299.99m, 1));
        order2.AddProduct(new Product("Mouse Wireless", "MW-100", 15.50m, 1));
        order2.AddProduct(new Product("USB-C Cable 6ft", "UC-2M", 10.00m, 3));

        Console.WriteLine("======================================");
        Console.WriteLine("🌍 Order 2: International Customer (Shipping: $35)");
        Console.WriteLine("======================================");
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine("--------------------------------------");
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine("--------------------------------------");
        Console.WriteLine($"Total Order Cost: ${order2.GetTotal():0.00}");
    }
}