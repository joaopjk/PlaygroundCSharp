#define RELATORIO_RESUMIDO

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace Reflections
{
    class Program
    {
        static void Main(string[] _)
        {
            Relatorio relatorio = new Relatorio("Relatório de Vendas");
            relatorio.Imprimir();

            //TAREFA 1: Imprimir relatório detalhado OU resumido de acordo com a compilação

            //TAREFA 2: Verificar se a classe Venda define o atributo [Serializable]

            //TAREFA 3: Impedir a serialização do campo nome do comprador

            //TAREFA 4: Definir na classe Venda os formatos de impressão detalhada e resumida

            Console.ReadLine();
        }
    }

    public class Venda
    {
        public string Data;
        public string Produto;
        public int Preco;
        public string TipoPagamento;
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

        [Conditional("RELATORIO_RESUMIDO")]
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

            foreach (var venda in vendas)
            {
                Console.WriteLine("{0}  {1}  {2}  {3}  {4}  {5}  {6}  {7}"
                            , venda.Data, venda.Produto, venda.Preco, venda.TipoPagamento, venda.Nome, venda.Cidade, venda.Estado, venda.Pais);
            }
            Console.WriteLine();
        }


        [Conditional("RELATORIO_RESUMIDO")]
        void ListagemResumida()
        {
            Console.WriteLine("Data          Produto         Preco       TipoPagamento   ");
            Console.WriteLine("==========================================================");


            foreach (var venda in vendas)
            {
                Console.WriteLine("{0}  {1}  {2}  {3}"
                    , venda.Data, venda.Produto, venda.Preco, venda.TipoPagamento);
            }
            Console.WriteLine();
        }
    }
}
