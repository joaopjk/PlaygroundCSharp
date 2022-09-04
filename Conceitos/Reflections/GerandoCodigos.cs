using System.CodeDom;
using System.CodeDom.Compiler;
using System.IO;

namespace Reflections
{
  static class GerandoCodigos
  {
    static void Main(string[] _)
    {
      //TAREFA: Utilizar código C# para gerar código C#,
      //          produzindo a classe Funcionario:

      /*
      namespace RecursosHumanos
      {
          using system;
          public class Funcionario
          {
              public string nome;
              public decimal salario;
              public Funcionario(string nome, decimal salario)
              {
              }
          }
      }
      */

      //Tarefa 1: criar uma unidade de compilação
      CodeCompileUnit unit = new();

      //Tarefa 2: criar o namespace RecursosHumanos
      CodeNamespace codeNamespace = new("RecursosHumanos");
      unit.Namespaces.Add(codeNamespace);

      //Tarefa 2.1: importar o namespace System
      CodeNamespaceImport import = new("System");
      codeNamespace.Imports.Add(import);

      //Tarefa 2.2: criar a classe Funcionario
      CodeTypeDeclaration funcionario = new("Funcionario");

      //Tarefa 2.3: criar o campo nome
      var nome = new CodeMemberField(typeof(string), "nome")
      {
        Attributes = MemberAttributes.Public
      };
      CodeMemberField salario = new(typeof(decimal), "salario")
      {
        Attributes = MemberAttributes.Public
      };
      //Tarefa 2.4: criar o campo salário
      //Tarefa 2.5: criar o construtor da classe

      //Tarefa 3: cria o provedor de modelo de código
      codeNamespace.Types.Add(funcionario);
      funcionario.Members.Add(nome);
      funcionario.Members.Add(salario);
      CodeDomProvider provider = CodeDomProvider.CreateProvider("CSharp");
      //Tarefa 4: gerar código e salva o arquivo
      using var sw = new StreamWriter("Funcionario.cs");
      provider.GenerateCodeFromCompileUnit(unit, sw, new CodeGeneratorOptions());
    }
  }
}
