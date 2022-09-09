using System;
using static System.Console;
using OpenTK;

#region 01 - Volume de uma caixa retangular
/*
Calcular o volume de uma caixa retangular mostra de forma simples como declarar variáveis e manipular dados de entrada e saída via console
O cálculo do volume é sempre dado pela multiplicação da altura (h), vezes a largura (L), vezes o comprimento (C).
*/

// double altura, largura, comprimento;

// WriteLine("Digte a altura da caixa: ");
// altura = Convert.ToDouble(ReadLine());

// WriteLine("Digite a largura da caixa");
// largura = Convert.ToDouble(ReadLine());

// WriteLine("Digite o comprimento da caixa");
// comprimento = Convert.ToDouble(ReadLine());

// WriteLine($"O volume da caixa é: {altura * largura * comprimento}");

#endregion

#region 02 - Converter temperatura em graus Fahrenheit para Celsius
//°C = (°F − 32) ÷ 1, 8

// WriteLine("Digite a temperatura em Fahrenheit: ");
// double fah = Convert.ToDouble(ReadLine());

// WriteLine($"{fah}° Fahrenheit em Celsius: {(fah - 32) / 1.8}°");

#endregion

#region  03 - Calcula volume de um cilindro
// const double pi = 3.1;

// WriteLine("Digite a altura do cilindro");
// double h = Convert.ToDouble(ReadLine());

// WriteLine("Digite o raio do cilindro");
// double r = Convert.ToDouble(ReadLine());

// WriteLine($"O volume do cilindro em cm³ é: {pi * h * (Math.Pow(r, 2))}");

#endregion

#region RotateCube
// var resolution = 25;
// var points = from i in Enumerable.Range(1, 8) select new Vector3(i / 4 % 2 * 2 - 1, i / 2 % 2 * 2 - 1, i % 2 * 2 - 1);
// var lines = from a in points
//             from b in points
//             where (a - b).Length == 2  // adjacent points
//                 && a.X + a.Y + a.Z > b.X + b.Y + b.Z // select each pair once
//             select new { a, b };
// var t = 0f;
// while (true)
// {
//   t += .1f;
//   var projection = Matrix4.CreatePerspectiveFieldOfView(.8f, 1, .01f, 100f);
//   var view = Matrix4.LookAt(2 * new Vector3((float)Math.Sin(t), .5f, (float)Math.Cos(t)), Vector3.Zero, Vector3.UnitY);
//   Console.Clear();
//   foreach (var line in lines)
//   {
//     for (int i = 0; i < resolution; i++)
//     {
//       var point = (1f / resolution) * (i * line.a + (resolution - 1 - i) * line.b); // interpolate a point between the two corners
//       var p1 = 5 * Vector3.Transform(point, view * projection) + new Vector3(30, 20, 0);
//       Console.SetCursorPosition((int)p1.X, (int)p1.Y);
//       Console.Write("#");
//     }
//   }
//   Console.ReadKey();
// }
#endregion