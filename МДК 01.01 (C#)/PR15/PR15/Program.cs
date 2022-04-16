using System;

namespace PR15
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(new Product("Вася"));
            // Проверка на то что конструктор лучше не обходить.
            try
            {
                Product product = new Product(null);
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}