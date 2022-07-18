// See https://aka.ms/new-console-template for more information
#region SortedList
IDictionary<string, Aluno> alunos = new Dictionary<string, Aluno>{
  {"VT", new Aluno("Vanessa", 34672)},
  {"AL", new Aluno("Ana", 5617)},
  {"RN", new Aluno("Rafael", 17645)},
  {"WM", new Aluno("Wanderson", 11287)},
};
foreach (var item in alunos)
{
    Console.WriteLine(item);
}
alunos.Add("MO", new Aluno("Marcelo", 1246));
Console.WriteLine();
foreach (var item in alunos)
{
    Console.WriteLine(item);
}
IDictionary<string, Aluno> sorted = new SortedList<string, Aluno>(alunos);
Console.WriteLine("SortedList ==========");
foreach (var item in sorted)
{
    Console.WriteLine(item);
}
#endregion
#region SorteDictionary

#endregion
class Aluno
{
    public string Nome { get; set; }
    public int NumeroMatricula { get; set; }
    public Aluno(string nome, int numeroMatricula)
    {
        Nome = nome;
        NumeroMatricula = numeroMatricula;
    }


    public override string ToString()
    {
        return $"[Aluno: {this.Nome} | Número Matrícula: {this.NumeroMatricula}";
    }
}