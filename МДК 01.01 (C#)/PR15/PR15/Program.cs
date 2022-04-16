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
            Cart.PrintCheck();
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