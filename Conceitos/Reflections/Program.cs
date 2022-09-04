#define RELATORIO_RESUMIDO

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Reflections
{
  static class Program
  {
    static void Main(string[] _)
    {
      Relatorio relatorio = new("Relatório de Vendas");
      relatorio.Imprimir();

      //TAREFA 1: Imprimir relatório detalhado OU resumido de acordo com a compilação

      //TAREFA 2: Verificar se a classe Venda define o atributo [Serializable]
      //if (Attribute.IsDefined(typeof(Produto), typeof(DataTableAttribute)))
      var contemOAtributoSerializable = Attribute.IsDefined(typeof(Venda), typeof(SerializableAttribute));
      Console.WriteLine(contemOAtributoSerializable);
      //TAREFA 3: Impedir a serialização do campo nome do comprador

      //TAREFA 4: Definir na classe Venda os formatos de impressão detalhada e resumida

      //Usuar Reflection: Programa olha para si mesmo para buscar algum atributo
      //Obtendo o tipo de relatio
      var tipoRelatorio = relatorio.GetType();
      Console.WriteLine(tipoRelatorio);
      Console.WriteLine("Obter os membros do relatório");
      var infoMembros = tipoRelatorio.GetMembers();
      infoMembros.AsQueryable().ToList().ForEach(x => Console.WriteLine(x.ToString()));
      //Enumerable.AsEnumerable(infoMembros).ToList();
      //Modificando um nome via reflection
      relatorio.Nome = "Nome modificado";//Sem reflection

      //Com reflection
      var metodo = tipoRelatorio.GetMethod("set_Nome");
      metodo.Invoke(relatorio, new object[] { "Nome novo relatio" });
      Console.ReadLine();

      Assembly este = Assembly.GetExecutingAssembly();
      var tipos = este.GetTypes();
      tipos.AsQueryable().ToList().ForEach(x =>
      {
        if (!x.IsInterface)
        {
          if (typeof(IRelatorio).IsAssignableFrom(x))
            Console.WriteLine("True");
        }
      });
    }
  }

  [Serializable]
  [FormatoResumidoAttribute("{0}  {1}  {2}  {3}")]
  [FormatoDetalhadoAttribute("{0}  {1}  {2}  {3}  {4}  {5}  {6}  {7}")]
  public class Venda
  {
    public string Data;
    public string Produto;
    public int Preco;
    public string TipoPagamento;
    [NonSerialized]
    public string Nome;
    public string Cidade;
    public string Estado;
    public string Pais;
    public string DataCriacao;
    public string UltimoLogin;
    public double Latitude;
    public double Longitude;
  }

  interface IRelatorio
  {
    string Nome { get; set; }
    void Imprimir();
  }

  class Relatorio : IRelatorio
  {
    public string Nome { get; set; }
    readonly IList<Venda> vendas;

    public Relatorio(string nome)
    {
      this.Nome = nome;
      vendas = JsonConvert.DeserializeObject<List<Venda>>(File.ReadAllText("Vendas.json"));
    }

    public void Imprimir()
    {
      Cabecalho();
      //#if RELATORIO_RESUMIDO : 1
      ListagemResumida();
      //#endif: 1
      //#if RELATORIO_DETALHADA: 1
      ListagemDetalhada();
      //#endif :1
      Console.WriteLine();
    }

    [Conditional("RELATORIO_RESUMIDO"),
     Conditional("RELATORIO_DETALHADA")]
    void Cabecalho()
    {
      Console.WriteLine(this.Nome);
      Console.WriteLine("=============================");
    }

    [Conditional("RELATORIO_DETALHADA")]
    void ListagemDetalhada()
    {
      Console.WriteLine("Data          Produto         Preco       TipoPagamento Nome                  Cidade                Região                Pais");
      Console.WriteLine("==========================================================================================================================================");

      FormatoDetalhadoAttribute fd = (FormatoDetalhadoAttribute)Attribute.GetCustomAttribute(typeof(Venda), typeof(FormatoDetalhadoAttribute));

      foreach (var venda in vendas)
      {
        Console.WriteLine(fd.Formato
                    , venda.Data, venda.Produto, venda.Preco, venda.TipoPagamento, venda.Nome, venda.Cidade, venda.Estado, venda.Pais);
      }
      Console.WriteLine();
    }

    [Conditional("RELATORIO_RESUMIDO")]
    void ListagemResumida()
    {
      Console.WriteLine("Data          Produto         Preco       TipoPagamento   ");
      Console.WriteLine("==========================================================");

      FormatoResumidoAttribute fd = (FormatoResumidoAttribute)Attribute.GetCustomAttribute(typeof(Venda), typeof(FormatoResumidoAttribute));

      foreach (var venda in vendas)
      {
        Console.WriteLine(fd.Formato
            , venda.Data, venda.Produto, venda.Preco, venda.TipoPagamento);
      }
      Console.WriteLine();
    }
  }

  [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
  class FormatoResumidoAttribute : Attribute
  {
    public string Formato { get; }
    public FormatoResumidoAttribute(string formato)
    {
      this.Formato = formato;
    }
  }

  [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
  class FormatoDetalhadoAttribute : Attribute
  {
    public string Formato { get; }

    public FormatoDetalhadoAttribute(string formato)
    {
      Formato = formato;
    }
  }
}
