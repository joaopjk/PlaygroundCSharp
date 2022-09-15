using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace Builders
{
  public class Product
  {
    private readonly List<object> _parts = new();

    public void Add(string part)
    {
      _parts.Add(part);
    }

    public string ListPart()
    {
      string str = string.Empty;

      for (int i = 0; i < _parts.Count; i++)
      {
        str = _parts[i] + ", ";
      }

      str = str.Remove(str.Length - 2);

      return "Products parts: " + str + "\n";
    }
  }
  public interface IBuilder
  {
    void BuildPartA();
    void BUildPartB();
    void BuildPartC();
  }

  public class ConcreteBuilder : IBuilder
  {
    private Product _product = new();
    public ConcreteBuilder()
    {
      this.Reset();
    }

    public void Reset()
    {
      _product = new Product();
    }
    public void BuildPartA()
    {
      _product.Add("PartA1");
    }

    public void BUildPartB()
    {
      _product.Add("PartB1");
    }

    public void BuildPartC()
    {
      _product.Add("PartC1");
    }

    public Product GetProduct()
    {
      Product result = _product;
      this.Reset();
      return result;
    }
  }

  public class Director
  {
    private IBuilder _builder;
    public IBuilder Builder { set { _builder = value; } }

    public void BuildMinimalViableProduct()
    {
      _builder.BuildPartA();
    }

    public void BuildFullFeatureProduct()
    {
      _builder.BuildPartA();
      _builder.BUildPartB();
      _builder.BuildPartC();
    }
  }
}