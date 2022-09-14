using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AbstractFactory
{
  interface IAbstractProductA
  {
    string UsefulFunctionA();
  }

  interface IAbstractProductB
  {
    string UsefulFunctionB();
    string AnotherUsefulFunctionB(IAbstractProductA collaborator);
  }

  interface IAbstractFactory
  {
    IAbstractProductA CreateProductA();
    IAbstractProductB CreateProductB();
  }

  class ConcreteProductA1 : IAbstractProductA
  {
    public string UsefulFunctionA()
    {
      return "The result of the product A1";
    }
  }

  class ConcreteProductA2 : IAbstractProductA
  {
    public string UsefulFunctionA()
    {
      return "The result of the product A2";
    }
  }

  class ConcreteProductB1 : IAbstractProductB
  {
    public string AnotherUsefulFunctionB(IAbstractProductA collaborator)
    {
      var result = collaborator.UsefulFunctionA();

      return $"The result of the B1 collaborating with the ({result})";
    }

    public string UsefulFunctionB()
    {
      return "The result of the product B1.";
    }
  }

  class ConcreteProductB2 : IAbstractProductB
  {
    public string AnotherUsefulFunctionB(IAbstractProductA collaborator)
    {
      var result = collaborator.UsefulFunctionA();

      return $"The result of the B2 collaborating with the ({result})";
    }

    public string UsefulFunctionB()
    {
      return "The result of the product B1.";
    }
  }

  class ConcreteFactory1 : IAbstractFactory
  {
    public IAbstractProductA CreateProductA()
    {
      return new ConcreteProductA1();
    }

    public IAbstractProductB CreateProductB()
    {
      return new ConcreteProductB1();
    }
  }

  class ConcreteFactory2 : IAbstractFactory
  {
    public IAbstractProductA CreateProductA()
    {
      return new ConcreteProductA2();
    }

    public IAbstractProductB CreateProductB()
    {
      return new ConcreteProductB2();
    }
  }
}