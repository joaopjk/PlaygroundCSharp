// See https://aka.ms/new-console-template for more information
#region SortedList
//Trabalha com duas listas
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
#region SortedDictionary
//Chaves -> Arvóre Binária | Valores -> Lista
IDictionary<string, Aluno> alunosD = new SortedDictionary<string, Aluno>{
  {"VT", new Aluno("Vanessa", 34672)},
  {"AL", new Aluno("Ana", 5617)},
  {"RN", new Aluno("Rafael", 17645)},
  {"WM", new Aluno("Wanderson", 11287)},
};
foreach (var item in alunosD)
{
    Console.WriteLine(item);
}
#endregion
#region SortedSet
//Só possuem valores, armazenados em arvoré binária.
ISet<string> alunosHS = new SortedSet<string>(new ComparadorMinusculo()) //Coleção ordenada
{
    "Vanessa Tonini",
    "Ana Lossak",
    "João Pedro",
    "Fábio Akkirahimari"
};

alunosHS.Add("Rafael Rollo");
alunosHS.Add("ANA LOSSAK");
foreach (var item in alunosHS)
{
    Console.WriteLine(item);
}
ISet<string> outroConjunto = new HashSet<string>();
alunosHS.IsProperSubsetOf(outroConjunto);
alunosHS.IsSupersetOf(outroConjunto);
alunosHS.SetEquals(outroConjunto);
alunosHS.ExceptWith(outroConjunto);
alunosHS.IntersectWith(outroConjunto);
alunosHS.SymmetricExceptWith(outroConjunto);
alunosHS.UnionWith(outroConjunto);
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
class ComparadorMinusculo : IComparer<string>
{
    public int Compare(string? x, string? y)
    {
        //Fazer a comparação entre os itens sem case sensitive
        return string.Compare(x, y, StringComparison.InvariantCultureIgnoreCase);
    }
}