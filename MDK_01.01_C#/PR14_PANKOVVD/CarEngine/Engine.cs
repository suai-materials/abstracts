namespace CarEngine;

public record Engine
{
    private string _name;
    private byte _markup;
    private Mark _mark;
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

    public string Mark
    {
        get => Enum.GetName(_mark)!;
        set => _mark = Enum.Parse<Mark>(value);
    }

    public DateTime Date { get; set; } = DateTime.Now;

    public string Markup
    {
        get => $"{_markup} %";
        set => _markup = byte.Parse(value.Substring(0, 2));
    }

    public double Cost => Math.Round(Price * QuantityOfCars * (1 + _markup / 100.0), 4);
}