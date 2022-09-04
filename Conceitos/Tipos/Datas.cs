using System;
using System.Globalization;

namespace Tipos
{
  public class Datas
  {
    static void args(string[] _)
    {
      /*
       * Sempre que trabalhar com DateTime.Now, utilizar o DateTime.UtcNow
       */
      var data = DateTime.UtcNow;
      Console.WriteLine(data);
      /*
       * Quando utilizar o construtor, utilizar da seguinte forma
       * DateTime (int year, int month, int day, int hour, int minute, int second, DateTimeKind kind).
       * Kind:
       *  - Utc: Representa a hora UTC
       *  - Unspecified: A hora representada não é especificada
       *  - Local: Representa a hora local
       */
      data = new DateTime(2021, 7, 30, 12, 05, 23, DateTimeKind.Utc);

      /*
       * Formatações
       */
      Console.WriteLine(data.ToString("yyyy-MM-dd HH:mm:ss"));
      Console.WriteLine(data.ToString("yyyy-MMMM-dd hh:mm:ss"));

      var cultureInfo = new CultureInfo("it-IT");
      Console.WriteLine(data.ToString("D", cultureInfo));
    }
  }
}
