namespace CarEngine;

public record Engine
{
    private int _id;
    private String _name = "";
    public CarType TypeOfProducedCars;
    public string CarModel = "";
    public uint Price;
    public DateTime Date;
    public char Markup;
    public uint QuantityOfCars;

    public String Name
    {
        get => _name;
        set
        {
            if (value is null || value.Trim() == "")
                throw new ArgumentException();
            _name = value;
        }
    }
    
    public int Id
    {
        get => _id;
    }

    public Engine()
    {
        
    }
    
    public Engine(string name, CarType typeOfProducedCars, string carModel, uint price, DateTime date, char markup)
    {
        (Name, TypeOfProducedCars, CarModel, Price, Date, Markup) = (name, typeOfProducedCars, carModel, price, date, markup);
    }
    
    
}