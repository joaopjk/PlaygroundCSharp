﻿using System;
using System.Collections.Generic;

namespace Bogus
{
    class Program
    {
        static void Main(string[] _)
        {
            var clientes = FakeDataClientes.ListaClientesFake();

            foreach (var cli in clientes)
            {
                Console.WriteLine(cli.Id);
                Console.WriteLine(cli.Nome);
                Console.WriteLine(cli.Email);
                Console.WriteLine(cli.Telefone);
                Console.WriteLine(cli.Endereco);
                Console.WriteLine(cli.Nascimento);
                Console.WriteLine(cli.Sexo);
                Console.WriteLine(cli.Ativo);
                Console.WriteLine(cli.Renda);
            }
        }
    }
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Endereco { get; set; }
        public DateTime Nascimento { get; set; }
        public string Sexo { get; set; }
        public bool Ativo { get; set; }
        public decimal Renda { get; set; }
    }

    public static class FakeDataClientes
    {
        public static List<Cliente> ListaClientesFake()
        {
            var clienteFaker = new Faker<Cliente>("pt_BR")
                .RuleFor(c => c.Id, f => f.IndexFaker)
                .RuleFor(c => c.Nome, f => f.Name.FullName(Bogus.DataSets.Name.Gender.Female))
                .RuleFor(c => c.Email, f => f.Internet.Email(f.Person.FirstName).ToLower())
                .RuleFor(c => c.Telefone, f => f.Person.Phone)
                .RuleFor(c => c.Endereco, f => f.Address.StreetAddress())
                .RuleFor(c => c.Nascimento, f => f.Date.Recent(100))
                .RuleFor(c => c.Sexo, f => f.PickRandom(new string[] { "masculino", "feminino" }))
                .RuleFor(c => c.Ativo, f => f.PickRandomParam(new bool[] { true, true, false }))
                .RuleFor(o => o.Renda, f => f.Random.Decimal(500, 2000));
            var clientes = clienteFaker.Generate(10);
            return clientes;
        }
    }
}
