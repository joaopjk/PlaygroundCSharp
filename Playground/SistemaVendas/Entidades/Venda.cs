using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaVendas.Entidades
{
    public class Venda
    {
        [Key]
        public int Codigo { get; set; }
        public string Data { get; set; }
        [ForeignKey("Cliente")]
        public int CodigoCliente { get; set; }
        public Cliente Cliente { get; set; }
        public decimal Total { get; set; }
        public ICollection<VendaProdutos> Produtos { get; set; }
    }
}
