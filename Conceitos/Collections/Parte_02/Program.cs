// See https://aka.ms/new-console-template for more information
Console.WriteLine("");
// #region SortedList
// //Trabalha com duas listas
// IDictionary<string, Aluno> alunos = new Dictionary<string, Aluno>{
//   {"VT", new Aluno("Vanessa", 34672)},
//   {"AL", new Aluno("Ana", 5617)},
//   {"RN", new Aluno("Rafael", 17645)},
//   {"WM", new Aluno("Wanderson", 11287)},
// };
// foreach (var item in alunos)
// {
//   Console.WriteLine(item);
// }
// alunos.Add("MO", new Aluno("Marcelo", 1246));
// Console.WriteLine();
// foreach (var item in alunos)
// {
//   Console.WriteLine(item);
// }
// IDictionary<string, Aluno> sorted = new SortedList<string, Aluno>(alunos);
// Console.WriteLine("SortedList ==========");
// foreach (var item in sorted)
// {
//   Console.WriteLine(item);
// }
// #endregion
// #region SortedDictionary
// //Chaves -> Arvóre Binária | Valores -> Lista
// IDictionary<string, Aluno> alunosD = new SortedDictionary<string, Aluno>{
//   {"VT", new Aluno("Vanessa", 34672)},
//   {"AL", new Aluno("Ana", 5617)},
//   {"RN", new Aluno("Rafael", 17645)},
//   {"WM", new Aluno("Wanderson", 11287)},
// };
// foreach (var item in alunosD)
// {
//   Console.WriteLine(item);
// }
// #endregion
// #region SortedSet
// //Só possuem valores, armazenados em arvoré binária.
// ISet<string> alunosHS = new SortedSet<string>(new ComparadorMinusculo()) //Coleção ordenada
// {
//     "Vanessa Tonini",
//     "Ana Lossak",
//     "João Pedro",
//     "Fábio Akkirahimari"
// };

// alunosHS.Add("Rafael Rollo");
// alunosHS.Add("ANA LOSSAK");
// foreach (var item in alunosHS)
// {
//   Console.WriteLine(item);
// }
// ISet<string> outroConjunto = new HashSet<string>();
// alunosHS.IsProperSubsetOf(outroConjunto);
// alunosHS.IsSupersetOf(outroConjunto);
// alunosHS.SetEquals(outroConjunto);
// alunosHS.ExceptWith(outroConjunto);
// alunosHS.IntersectWith(outroConjunto);
// alunosHS.SymmetricExceptWith(outroConjunto);
// alunosHS.UnionWith(outroConjunto);
// #endregion
// #region ArrayMultidimensional
// string[,] resultados = new string[3, 3];
// //{
// //    {"Alemanha","Espanha","Itália" },
// //    {"Argentina","Holanda","França" },
// //    {"Holanda","Alemanha","Alemanha" }
// //};
// resultados[0, 0] = "Alemanha";
// resultados[1, 0] = "Argentina";
// resultados[2, 0] = "Holanda";

// resultados[0, 1] = "Espanha";
// resultados[1, 1] = "Holanda";
// resultados[2, 1] = "Alemanha";

// resultados[0, 2] = "Itália";
// resultados[1, 2] = "França";
// resultados[2, 2] = "Alemanha";
// //foreach (var item in resultados)
// //{
// //    Console.WriteLine(item);
// //}
// for (int copa = 0; copa < 3; copa++)
// {
//   int ano = 2014 - (copa * 4);
//   Console.Write(ano.ToString().PadRight(12));
// }
// Console.WriteLine();
// for (int copa = 0; copa < 3; copa++)
// {
//   Console.Write(resultados[0, copa].PadRight(12));
// }
// #endregion
// #region JaggedArrays
// string[][] familias = new string[3][];
// //{
// //        {"Fred", "Wilma", "Pedrita"},
// //        {"Homer", "Marge", "Lisa", "Bart", "Maggie"},
// //        "{Florinda", "Kiko}"
// //};

// familias[0] = new string[] { "Fred", "Wilma", "Pedrita" };
// familias[1] = new string[] { "Homer", "Marge", "Lisa", "Bart", "Maggie" };
// familias[2] = new string[] { "Florinda", "Kiko" };
// #endregion
// #region Consultando Collections
// List<Mes> meses = new()
// {
//     new Mes("Janeiro", 31),
//     new Mes("Janeiro", 31),
//     new Mes("Fevereiro", 28),
//     new Mes("Março", 31),
//     new Mes("Abril", 30),
//     new Mes("Maio", 31),
//     new Mes("Junho", 30),
//     new Mes("Julho", 31),
//     new Mes("Agosto", 31),
//     new Mes("Setembro", 30),
//     new Mes("Outubro", 31),
//     new Mes("Novembro", 30),
//     new Mes("Dezembro", 31)
// };
// IEnumerable<Mes> consultas = meses
//     .Where(x => x.Dias == 31)
//     .OrderBy(x => x.Nome);
// #endregion
// class Aluno
// {
//   public string Nome { get; set; }
//   public int NumeroMatricula { get; set; }
//   public Aluno(string nome, int numeroMatricula)
//   {
//     Nome = nome;
//     NumeroMatricula = numeroMatricula;
//   }
//   public override string ToString()
//   {
//     return $"[Aluno: {this.Nome} | Número Matrícula: {this.NumeroMatricula}";
//   }
// }
// class ComparadorMinusculo : IComparer<string>
// {
//   public int Compare(string? x, string? y)
//   {
//     //Fazer a comparação entre os itens sem case sensitive
//     return string.Compare(x, y, StringComparison.InvariantCultureIgnoreCase);
//   }
// }
// class Mes
// {
//   public Mes(string nome, int dias)
//   {
//     Nome = nome;
//     Dias = dias;
//   }
//   public string Nome { get; private set; }
//   public int Dias { get; private set; }
//   public override string ToString()
//   {
//     return $"{Nome} - {Dias}";
//   }
// }