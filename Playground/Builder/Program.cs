using System.Text;
using static System.Console;

namespace Builder
{
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
            #region Stepwise Builder
            var car = CarBuilder.Create()
                .OfType(CarType.Crossover)
                .WithWheels(18)
                .Build();
            WriteLine(car);
            #endregion
            #region Functional Builder
            var personF = new PersonBuilderF()
                .Called("João")
                .WorkAs("Developer")
                .Build();
            #endregion
            #region Faceted Builder
            var pb = new PersonBuilderFC();
            var personFc = pb
                .Worker
                .At("Localiza")
                .AsA("Developer")
                .Earning(100000);
            #endregion
        }
    }
}
