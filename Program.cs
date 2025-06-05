using System;
using System.Collections.Generic;

public class Product
{
    public string Name { get; set; }
    public int Quantity { get; set; }

    public Product(string name, int quantity)
    {
        Name = name;
        Quantity = quantity;
    }
}

class Program
{
    static List<Product> inventory = new();

    static void Main()
    {
        bool running = true;

        while (running)
        {
            Console.WriteLine("\n-- Inventory Tracker --");
            Console.WriteLine("1. Add product");
            Console.WriteLine("2. View products");
            Console.WriteLine("3. Delete product");
            Console.WriteLine("4. Exit");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1": AddProduct(); break;
                case "2": ViewProducts(); break;
                case "3": DeleteProduct(); break;
                case "4": running = false; break;
                default: Console.WriteLine("Invalid option."); break;
            }
        }
    }

    static void AddProduct()
    {
        Console.Write("Enter product name: ");
        string name = Console.ReadLine();
        Console.Write("Enter quantity: ");
        int qty = int.Parse(Console.ReadLine());

        inventory.Add(new Product(name, qty));
        Console.WriteLine("Product added!");
    }

    static void ViewProducts()
    {
        if (inventory.Count == 0)
        {
            Console.WriteLine("No products in inventory.");
            return;
        }

        Console.WriteLine("\n-- Current Inventory --");
        for (int i = 0; i < inventory.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {inventory[i].Name} - Qty: {inventory[i].Quantity}");
        }
    }

    static void DeleteProduct()
    {
        ViewProducts();
        Console.Write("Enter product number to delete: ");
        int index = int.Parse(Console.ReadLine()) - 1;

        if (index >= 0 && index < inventory.Count)
        {
            inventory.RemoveAt(index);
            Console.WriteLine("Product deleted.");
        }
        else
        {
            Console.WriteLine("Invalid index.");
        }
    }
}

