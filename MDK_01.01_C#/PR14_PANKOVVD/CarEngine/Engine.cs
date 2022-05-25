namespace CarEngine;

public record Engine
{
    private int _id;
    private string _name;
    public CarType TypeOfProducedCars { get; set; }
    public string Mark { get; set; }
    public uint Price { get; set; }
    public DateTime Date { get; set; }
    public byte Markup { get; set; }

    public uint QuantityOfCars { get; set; }
    // public uint Percent { get; set; }

    public double Cost => Price * QuantityOfCars * (1 + Markup / 100f);

    public string Name
    {
        get => _name;
        set
        {
            if (value is null || value.Trim() == "")
                throw new ArgumentException();
            _name = value;
        }
    }

    public int Id => _id;

    public Engine()
    {
    }

    public Engine(string name, CarType typeOfProducedCars, string mark, uint price, DateTime date, byte markup)
    {
        (Name, TypeOfProducedCars, Mark, Price, Date, Markup) =
            (name, typeOfProducedCars, mark, price, date, markup);
    }
}