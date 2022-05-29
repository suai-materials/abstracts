namespace CarEngine;

public record Engine
{
    private string _name;
    private byte _markup;
    public uint? Id { get; set; }


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

    public uint Price { get; set; }
    public uint QuantityOfCars { get; set; }

    public CarType TypeOfProducedCars { get; set; }
    public string Mark { get; set; }

    public DateTime Date { get; set; } = DateTime.Now;

    public string Markup
    {
        get => $"{_markup} %";
        set => _markup = byte.Parse(value.Substring(0, 2));
    }

    // public uint Percent { get; set; }

    public double Cost => Math.Round(Price * QuantityOfCars * (1 + _markup / 100.0), 4);


    public Engine()
    {
    }

    public Engine(string name, CarType typeOfProducedCars, string mark, uint price, DateTime date, string markup)
    {
        (Name, TypeOfProducedCars, Mark, Price, Date, Markup) =
            (name, typeOfProducedCars, mark, price, date, markup);
    }
}