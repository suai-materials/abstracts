namespace CarEngine;

public class EngineList : List<Engine>
{
    public double Cost => Math.Round(this.Sum(s => s.Cost), 4);

    public double MiddleCost => Math.Round(this.Average(s => s.Cost), 4);

    // Добавление заводов, так чтобы у них были уникальные индефикаторы
    public void AddEngine(Engine engine)
    {
        if (Contains(engine))
            return;
        if (Count == 0)
            engine.Id = 1;
        else engine.Id = this.Max(s => s.Id) + 1;
        Add(engine);
    }

    public void UpdateEngine(Engine engine)
    {
        this[IndexOf(Find(engine1 => engine1.Id == engine.Id)!)] = engine;
    }
}