using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SistemaVendas.Models
{
    public class ProdutoViewModel
    {
        public int? Codigo { get; set; }
        [Required(ErrorMessage = "Informe a descrição do Produto!")]
        public string Descricao { get; set; }
        [Required(ErrorMessage = "Informe a quantidade do Produto!")]
        public double Quantidade { get; set; }
        [Required(ErrorMessage = "Informe o valor do Produto!")]
        public decimal Valor { get; set; }
        [Required(ErrorMessage = "Informe a Categoria do Produto!")]
        public int? CodigoCategoria { get; set; }
        public IEnumerable<SelectListItem> ListaCategorias { get; set; }
    }
}
