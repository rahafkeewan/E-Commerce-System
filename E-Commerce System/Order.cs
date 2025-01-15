using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_System
{
    public class Order
    {
        private List<Product> _products = new List<Product>();

        public void AddProduct(Product product)
        {
            _products.Add(product);
            Console.WriteLine($"Product {product.Name} added to order.");
        }

        public void RemoveProduct(int productId)
        {
            var product = _products.Find(p => p.Id == productId);
            if (product != null)
            {
                _products.Remove(product);
                Console.WriteLine($"Product {product.Name} removed from order.");
            }
            else
            {
                Console.WriteLine("Product not found.");
            }
        }

        public void ShowOrderSummary()
        {
            Console.WriteLine("\nOrder Summary:");
            decimal total = 0;
            foreach (var product in _products)
            {
                Console.WriteLine(product);
                total += product.Price;
            }
            Console.WriteLine($"Total: {total:C}");
        }
    }

}
