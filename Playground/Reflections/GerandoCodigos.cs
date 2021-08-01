using System;
using System.Collections.Generic;
using System.Text;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.IO;

namespace Reflections
{
    class GerandoCodigos
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
            CodeCompileUnit unit = new CodeCompileUnit();

            //Tarefa 2: criar o namespace RecursosHumanos
            CodeNamespace codeNamespace = new CodeNamespace("RecursosHumanos");
            unit.Namespaces.Add(codeNamespace);
            //Tarefa 2.1: importar o namespace System
            //Tarefa 2.2: criar a classe Funcionario
            //Tarefa 2.3: criar o campo nome
            //Tarefa 2.4: criar o campo salário
            //Tarefa 2.5: criar o construtor da classe

            //Tarefa 3: cria o provedor de modelo de código
            CodeDomProvider provider = CodeDomProvider.CreateProvider("CSharp");
            //Tarefa 4: gerar código e salva o arquivo
            using (var sw = new StreamWriter("Funcionario.cs"))
            {
                provider.GenerateCodeFromCompileUnit(unit, sw, new CodeGeneratorOptions());
            }
        }
    }
}
