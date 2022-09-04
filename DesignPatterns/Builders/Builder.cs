using System;
using System.Collections.Generic;
using System.Text;

namespace Builder
{
  public class HtmlElement
  {
    public string Name, Text;
    public List<HtmlElement> Elements = new();
    private const int indentSize = 2;

    public HtmlElement() { }

    public HtmlElement(string name, string text)
    {
      Name = name ?? throw new ArgumentNullException(nameof(name));
      Text = text ?? throw new ArgumentNullException(nameof(text));
    }

    private string ToStringImp(int indent)
    {
      var sb = new StringBuilder();
      var i = new string(' ', indentSize * indent);
      sb.Append(i).Append('<').Append(Name).AppendLine(">");
      if (!string.IsNullOrEmpty(Text))
      {
        sb.Append(new string(' ', indentSize * (indent + 1)));
        sb.AppendLine(Text);
      }
      foreach (var e in Elements)
      {
        sb.Append(e.ToStringImp(indent + 1));
      }
      sb.Append(i).Append("</").Append(Name).AppendLine(">");
      return sb.ToString();
    }

    public override string ToString()
    {
      return ToStringImp(0);
    }
  }

  class HtmlBuilder
  {
    private readonly string rootName;
    HtmlElement root = new();
    public HtmlBuilder(string rootName)
    {
      this.rootName = rootName;
      root.Name = rootName;
    }

    public HtmlBuilder AddChild(string childName, string childText)
    {
      var e = new HtmlElement(childName, childText);
      root.Elements.Add(e);
      return this;
    }

    public override string ToString()
    {
      return root.ToString();
    }

    public void Clear()
    {
      root = new HtmlElement { Name = this.rootName };
    }
  }
}
