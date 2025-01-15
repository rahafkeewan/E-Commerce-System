using System;
using System.Collections.Generic;

namespace E_Commerce_System
{
    class Program
    {
        static void Main(string[] args)
        {
            Customer customer = new Customer();
            Order order = new Order();

            while (true)
            {
                Console.WriteLine("\n--- E-Commerce System ---");
                Console.WriteLine("1. Update Customer Info");
                Console.WriteLine("2. Add Product");
                Console.WriteLine("3. Remove Product");
                Console.WriteLine("4. Show Order Summary");
                Console.WriteLine("5. Process Payment");
                Console.WriteLine("6. Exit");

                Console.Write("Choose an option: ");
                int choice = int.Parse(Console.ReadLine() ?? "0");

                switch (choice)
                {
                    case 1:
                        Console.Write("Enter Name: ");
                        string name = Console.ReadLine();
                        Console.Write("Enter Address: ");
                        string address = Console.ReadLine();
                        Console.Write("Enter Contact: ");
                        string contact = Console.ReadLine();
                        customer.UpdateDetails(name, address, contact);
                        break;

                    case 2:
                        Console.Write("Enter Product ID: ");
                        int id = int.Parse(Console.ReadLine() ?? "0");
                        Console.Write("Enter Product Name: ");
                        string productName = Console.ReadLine();
                        Console.Write("Enter Product Price: ");
                        decimal price = decimal.Parse(Console.ReadLine() ?? "0");
                        order.AddProduct(new Product(id, productName, price));
                        break;

                    case 3:
                        Console.Write("Enter Product ID to Remove: ");
                        int removeId = int.Parse(Console.ReadLine() ?? "0");
                        order.RemoveProduct(removeId);
                        break;

                    case 4:
                        order.ShowOrderSummary();
                        break;

                    case 5:
                        Console.WriteLine("Choose Payment Method:\n1. Credit Card\n2. PayPal");
                        int paymentChoice = int.Parse(Console.ReadLine() ?? "0");
                        decimal amount = 0;
                        foreach (var product in order.GetType().GetField("_products", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).GetValue(order) as List<Product>)
                            amount += product.Price;

                        IPaymentProcessor paymentProcessor = paymentChoice == 1 ? new CreditCardPayment() : new PayPalPayment() as IPaymentProcessor;
                        paymentProcessor.ProcessPayment(amount);
                        break;

                    case 6:
                        Console.WriteLine("Exiting system. Goodbye!");
                        return;

                    default:
                        Console.WriteLine("Invalid option. Try again.");
                        break;
                }
            }
        }
    }
}
