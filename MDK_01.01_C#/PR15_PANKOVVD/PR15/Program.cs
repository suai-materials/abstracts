using System;

namespace PR15
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Демонстрация вывода");
            Console.WriteLine(new Product("Test"));
            Console.WriteLine("\nДемонстрация создания продуктов:");
            var cucumbers = new Product("Огурцы", 105.6, 12);
            var pepsi = new Product("Pepsi", 153);
            var theDarkTower = new Product("The Dark Tower");
            Console.WriteLine($"{cucumbers}\n{pepsi}\n{theDarkTower}");
            Console.WriteLine("\nДемонстрация создания продукта без имени: ");
            try
            {
                var errorProduct = new Product(null);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            try
            {
                var errorProduct = new Product("  ");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            try
            {
                var errorProduct = new Product("");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine("\nДемонстрация изменения продукта:");
            Console.WriteLine(cucumbers);
            cucumbers.Price++;
            Console.WriteLine(cucumbers);
            cucumbers.Quantity++;
            Console.WriteLine(cucumbers);
            cucumbers.Name = "Огурцы с солью";
            Console.WriteLine(cucumbers);
            cucumbers++;
            Console.WriteLine(cucumbers);
            cucumbers--;
            Console.WriteLine(cucumbers);
            cucumbers.AddQuality(10000);
            Console.WriteLine(cucumbers);
            cucumbers.AddQuality(-10000);
            Console.WriteLine(cucumbers);
            cucumbers.AddQuality(-10000);
            Console.WriteLine(cucumbers);
            cucumbers.AddQuality(int.MaxValue);
            cucumbers++;
            Console.WriteLine(cucumbers);
            Console.WriteLine();
            Console.WriteLine("Демонстрация сравнения: ");
            Console.WriteLine(cucumbers == theDarkTower);
            Console.WriteLine(cucumbers != theDarkTower);
            theDarkTower = cucumbers;
            Console.WriteLine(cucumbers == theDarkTower);
            Console.WriteLine(cucumbers != theDarkTower);

            Console.WriteLine("\nДемонстрация проверки вхождения цены/стоимости в диапазон");
            cucumbers.AddQuality(2);
            Console.WriteLine(cucumbers);
            Console.WriteLine(cucumbers.IsInCostRange(100, 110));
            Console.WriteLine(cucumbers.IsInCostRange(200, 250));
            Console.WriteLine(cucumbers.IsInPriceRange(100, 110));
            Console.WriteLine(cucumbers.IsInPriceRange(200, 250));
            
            Console.WriteLine("\nРабота с корзиной");
            cucumbers.AddToCart();
            Cart.AddProduct(pepsi);
            Cart.PrintCheck();
            Cart.AddProduct(cucumbers);
            Console.WriteLine();
            pepsi.AddToCart();
            Cart.PrintCheck();
            Console.WriteLine();
            Console.WriteLine("Явное и неявное преобразование");
            double d = (double) pepsi;
            Console.WriteLine(d);
            string str = pepsi + " Я Вася";
            Console.WriteLine(str);
        }
    }
}