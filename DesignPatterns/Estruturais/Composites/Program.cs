using System;

namespace Composites
{
  static class Program
  {
    static void Main(string[] _)
    {
      //Geometric Shape
      var drawing = new GraphicObject { Name = "My Drawing" };
      drawing.Children.Add(new Square { Color = "Red" });
      drawing.Children.Add(new Circle { Color = "Yellow" });

      var group = new GraphicObject();
      group.Children.Add(new Circle { Color = "Blue" });
      group.Children.Add(new Square { Color = "Black" });

      drawing.Children.Add(group);
    }
  }
}
