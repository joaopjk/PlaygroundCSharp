using System;
using System.Collections.Generic;
using System.Text;

namespace Composites
{
  class GraphicObject
  {
    public virtual string Name { get; set; } = "Group";
    public string Color;

    private readonly Lazy<List<GraphicObject>> children = new();
    public List<GraphicObject> Children => children.Value;

    private void Print(StringBuilder sb, int depth)
    {
      sb.Append(new string('*', depth))
      .Append(string.IsNullOrEmpty(Color) ? string.Empty : $"{Color}")
      .AppendLine(Name);

      foreach (var child in Children)
        child.Print(sb, depth + 1);
    }

    public override string ToString()
    {
      var sb = new StringBuilder();
      Print(sb, 0);
      return sb.ToString();
    }
  }

  class Circle : GraphicObject
  {
    public override string Name => "Circle";
  }

  class Square : GraphicObject
  {
    public override string Name => "Square";
  }
}