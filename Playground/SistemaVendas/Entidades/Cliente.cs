using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SistemaVendas.Entidades
{
    public class Cliente
    {
        [Key]
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public string CPNJ_CPF { get; set; }
        public string Email { get; set; }
        public string Celular { get; set; }
        public ICollection<Venda> Vendas { get; set; }
    }
}
