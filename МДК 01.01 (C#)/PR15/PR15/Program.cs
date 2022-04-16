using System;

namespace PR15
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(new Product("Вася"));
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