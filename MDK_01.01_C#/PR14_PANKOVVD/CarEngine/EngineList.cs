namespace CarEngine;

public class EngineList : List<Engine>
{
    public double GetCost()
    {
        return this.Sum(s => s.Cost);
    }

    // Добавление заводов, так чтобы у них были уникальные индефикаторы
    public void AddEngine(Engine engine)
    {
        if (Count == 0)
            engine.Id = 1;
        else engine.Id = this.Max(s => s.Id) + 1;
        Add(engine);
    }
}