using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SistemaVendas.Models
{
    public class VendaViewModel
    {
        public int? Codigo { get; set; }
        [Required(ErrorMessage = "O campo data é obrigatório!")]
        public DateTime Data { get; set; }
        [Required(ErrorMessage = "Informe o Codigo do Cliente!")]
        public int? CodigoCliente { get; set; }
        public decimal Total { get; set; }
        public IEnumerable<SelectListItem> ListaClientes { get; set; }
        public IEnumerable<SelectListItem> ListaProdutos { get; set; }
        public string JsonProdutos { get; set; }
    }
}
