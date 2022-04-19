using System;
using System.Collections.Generic;
using System.Linq;

namespace PR15
{
    public static class Cart
    {
        private static HashSet<Product> _productList = new();

        public static void AddProduct(Product product)
        {
            if (_productList.Contains(product))
                _productList.Where(p => p == product).ToArray()[0].AddQuality(product.Quantity);
            else
                _productList.Add(product);
        }

        // Вывод красивого чека
        public static void PrintCheck()
        {
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("Чек: ");
            Console.ResetColor();
            double cartCost = 0;
            foreach (var el in _productList)
            {
                Console.WriteLine(el);
                cartCost += el.Cost;
            }
            Console.WriteLine(new string('-', 100));
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine($"Итог: {cartCost} д.е. ");
            Console.ResetColor();
        }
    }
}