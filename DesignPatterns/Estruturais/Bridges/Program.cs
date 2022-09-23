using System;

namespace Bridges
{
  interface IRenderer
  {
    void RenderCircle(float radius);
  }

  class VectorRenderer : IRenderer
  {
    public void RenderCircle(float radius)
    {
      Console.WriteLine($"Drawing a circle of radius {radius}");
    }
  }

  class RasterRenderer : IRenderer
  {
    public void RenderCircle(float radius)
    {
      Console.WriteLine($"Drawing pixels for circle with radius {radius}");
    }
  }

  //Bridge
  abstract class Shape
  {
    protected IRenderer renderer;

    protected Shape(IRenderer renderer)
    {
      this.renderer = renderer;
    }

    public abstract void Draw();
    public abstract void Resize(float factor);
  }

  class Circle : Shape
  {
    private float _radius;
    public Circle(IRenderer renderer, float radius) : base(renderer)
    {
      _radius = radius;
    }

    public override void Draw()
    {
      renderer.RenderCircle(_radius);
    }

    public override void Resize(float factor)
    {
      _radius *= factor;
    }
  }

  static class Program
  {
    static void Main(string[] _)
    {
      // var renderer = new RasterRenderer();
      var renderer = new RasterRenderer();
      var circle = new Circle(renderer, 5);
      circle.Draw();
      circle.Resize(2);
      circle.Draw();
    }
  }
}
