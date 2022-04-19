using System;

namespace PR15
{
    class Program
    {
        static void Main(string[] args)
        {
            var vasya = new Product("Вася", 12, 12);
            Console.WriteLine(vasya);
            vasya.AddToCart();
            vasya.AddToCart();
            double d = (double) vasya;
            var Pivo = new Product("Beer", 24, Int32.MaxValue);
            Pivo++;
            Pivo++;
            Console.WriteLine(Pivo);
            Console.WriteLine(d);
            Cart.PrintCheck();
            Console.WriteLine(vasya.IsInPriceRange(10, 40));
            Console.WriteLine(vasya.IsInCostRange(10, 200));
            // Проверка на то что имя должно быть не пустое
            try
            {
                Product product = new Product("   ");
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}