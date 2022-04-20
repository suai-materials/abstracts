using System;

namespace ClassLibrary_Stock
{
    public class Product
    {
        public string Name { get; set; }
        public string Article { get; set; }
        public uint Price { get; set; }
        public UnitMessure Unit { get; set; }
        public float Marge { get; set; }
        public DateTime DateOfReceipt { get; set; }
        public double Quantity { get; }

        public Product()
        {
            (Name, Article, Price, Unit, Marge, DateOfReceipt, Quantity) = ("Новый товар", "XXX-000-00", 0,
                UnitMessure.штука, 0, DateTime.Today, 0);
        }

        public Product(string name = "Новый товар", string article = "XXX-000-00", uint price = 0, UnitMessure unit = UnitMessure.штука, float merge = 0,
            DateTime date = default, double quantity = 0)
        {
            (Name, Article, Price, Unit, Marge, DateOfReceipt, Quantity) = (name, article, price,
                unit, merge, date, quantity);
        }
    }
}