using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

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
            sb.AppendLine($"{i}<{Name}>");
            if (!string.IsNullOrEmpty(Text))
            {
                sb.Append(new string(' ', indentSize * (indent + 1)));
                sb.AppendLine(Text);
            }
            foreach (var e in Elements)
            {
                sb.Append(e.ToStringImp(indent + 1));
            }
            sb.AppendLine($"{i}</{Name}>");
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

    class Program
    {
        static void Main(string[] _)
        {
            #region StringBuilder
            var hello = "hello";
            var sb = new StringBuilder();
            sb.Append("<p>");
            sb.Append(hello);
            sb.Append("</p>");
            WriteLine(sb);

            var words = new[] { "hello", "world" };
            sb.Clear();
            sb.Append("<ul>");
            foreach (var word in words)
            {
                sb.AppendFormat("<li>{0}</li>", word);
            }
            sb.Append("<ul>");
            WriteLine(sb);
            #endregion
            #region Builder
            var builder = new HtmlBuilder("ul");
            //builder.AddChild("li", "hello");
            //builder.AddChild("li", "world");
            builder.AddChild("li", "hello")
                   .AddChild("li", "world");
            WriteLine(builder.ToString());
            #endregion
            #region Fluent Builder with Generics
            var me = Person.New
                .Called("João")
                .WorkAs("Development")
                .Build();
            WriteLine(me);
            #endregion
        }
    }
}
