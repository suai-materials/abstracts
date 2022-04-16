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
                _productList.Add(product);
            else
                _productList.Where(p => p == product).ToArray()[0]++;
        }

        public static void PrintCheck()
        {
            double cartCost = 0;
            foreach (var el in _productList)
            {
                Console.WriteLine(el);
                cartCost += el.Cost;
            }
            Console.WriteLine(new string('-', 20) + "\n\n");
            Console.WriteLine($"Итог: {cartCost}");
        }
    }
}