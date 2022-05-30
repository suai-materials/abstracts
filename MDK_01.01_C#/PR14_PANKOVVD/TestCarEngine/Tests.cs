using CarEngine;
using NUnit.Framework;

namespace TestProject1;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void EmptyEngineCostTest()
    {
        Engine engine = new Engine();
        Assert.AreEqual(engine.Cost, 0.0);
    }

    [Test]
    public void CostTest1()
    {
        Engine engine = new Engine{Price = 10};
        Assert.AreEqual(engine.Cost, 0.0);
    }
    [Test]
    public void CostTest2()
    {
        Engine engine = new Engine{Price = 10, QuantityOfCars = 10};
        Assert.AreEqual(engine.Cost, 100.0);
    }
    [Test]
    public void CostTest3()
    {
        Engine engine = new Engine{Price = 10, QuantityOfCars = 20};
        Assert.AreEqual(engine.Cost, 200.0);
    }
    [Test]
    public void CostTest4()
    {
        Engine engine = new Engine{Price = 10, QuantityOfCars = 10, Markup = "10 %"};
        Assert.AreEqual(engine.Cost, 110.0);
    }
    [Test]
    public void CostTest5()
    {
        Engine engine = new Engine{Price = 1, QuantityOfCars = 1, Markup = "10 %"};
        Assert.AreEqual(engine.Cost, 1.1); // Ошибка с плавующей запятой
    }

    [Test]
    public void EngineListTest()
    {
        EngineList list = new EngineList();
        list.AddEngine(new Engine());
        list.AddEngine(new Engine());
        list.AddEngine(new Engine());
        Assert.AreEqual(list.Cost, 0.0);
        Assert.AreEqual(list.Count, 3);
        Assert.AreEqual(list[2].Id, 3);
    }
    [Test]
    public void EngineListCostAvarageTest()
    {
        EngineList list = new EngineList();
        list.AddEngine(new Engine{QuantityOfCars = 1, Price = 1});
        list.AddEngine(new Engine{QuantityOfCars = 1, Price = 1});
        list.AddEngine(new Engine{QuantityOfCars = 1, Price = 1});
        Assert.AreEqual(list.Cost, 3.0);
        Assert.AreEqual(list.MiddleCost, 1.0);
    }
}