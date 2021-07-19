using ByteBank.Core.Repository;
using ByteBank.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace ByteBank.View
{
    public partial class MainWindow : Window
    {
        private readonly ContaClienteRepository r_Repositorio;
        private readonly ContaClienteService r_Servico;

        public MainWindow()
        {
            InitializeComponent();

            r_Repositorio = new ContaClienteRepository();
            r_Servico = new ContaClienteService();
        }

        private void BtnProcessar_Click(object sender, RoutedEventArgs e)
        {
            var taskScheduleUi = TaskScheduler.FromCurrentSynchronizationContext();
            var contas = r_Repositorio.GetContaClientes();

            var resultado = new List<string>();

            AtualizarView(new List<string>(), TimeSpan.Zero);

            var inicio = DateTime.Now;

            //var contas_parte1 = contas.Take(contas.Count() / 2);
            //var contas_parte2 = contas.Skip(contas.Count() / 2);

            //Thread t1 = new Thread(() =>
            //{
            //    foreach (var conta in contas_parte1)
            //    {
            //        var resultadoConta = r_Servico.ConsolidarMovimentacao(conta);
            //        resultado.Add(resultadoConta);
            //    }
            //});

            //Thread t2 = new Thread(() =>
            //{
            //    foreach (var conta in contas_parte2)
            //    {
            //        var resultadoConta = r_Servico.ConsolidarMovimentacao(conta);
            //        resultado.Add(resultadoConta);
            //    }
            //});

            //t1.Start();
            //t2.Start();

            //while (t1.IsAlive || t2.IsAlive)
            //{
            //    Thread.Sleep(250);
            //    //Não vou fazer nada
            //}

            var contasTarefas = contas.Select(conta =>
            {
                //TaskScheduler
                return Task.Factory.StartNew(() =>
                {
                    var resultadoConta = r_Servico.ConsolidarMovimentacao(conta);
                    resultado.Add(resultadoConta);
                });
            }).ToArray();

            //Task.WaitAll(contasTarefas);

            Task.WhenAll(contasTarefas)
                .ContinueWith(task =>
                {
                    var fim = DateTime.Now;

                    AtualizarView(resultado, fim - inicio);
                }, taskScheduleUi);
        }

        private void AtualizarView(List<String> result, TimeSpan elapsedTime)
        {
            var tempoDecorrido = $"{ elapsedTime.Seconds }.{ elapsedTime.Milliseconds} segundos!";
            var mensagem = $"Processamento de {result.Count} clientes em {tempoDecorrido}";

            LstResultados.ItemsSource = result;
            TxtTempo.Text = mensagem;
        }
    }
}
