using System;

namespace PR15
{
    public class Product
    {
        private string _name;
        private float _cost;
        private uint _quantity;

        public float Cost
        {
            get => _cost;
            set => _cost = value;
        }

        public uint Quantity
        {
            get => _quantity;
            set => _quantity = value;
        }

        public string Name
        {
            get => _name;
            set => _name = value;
        }

        public Product(string name, float cost = 0, uint quantity = 1)
        {
            if (name is null)
                throw new NullReferenceException("Имя должно быть задано");
            (Name, Cost, Quantity) = (name, cost, quantity);
        }
        
        public override string ToString()
        {
            return $"Товар {Name}, цена за одну единицу товар {Cost}, в количестве {Quantity}. Стоимость: {Quantity * Cost}";
        }

        public static Product operator ++(Product product)
        {
            product.Quantity++;
            return product;
        }

        public static Product operator --(Product product)
        {
            product.Quantity--;
            return product;
        }

        public static Product operator -(Product product, uint n)
        {
            return new Product(product.Name) {Cost = product.Cost, Quantity = product.Quantity - n};
        }
        public static Product operator +(Product product, uint n)
        {
            return new Product(product.Name) {Cost = product.Cost, Quantity = product.Quantity + n};
        }

        public void Print()
        {
            Console.WriteLine(this);
        }
    }
}