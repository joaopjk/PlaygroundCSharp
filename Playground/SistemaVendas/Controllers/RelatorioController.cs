using Microsoft.AspNetCore.Mvc;
using SistemaVendas.DAL;
using SistemaVendas.Models;
using System;
using System.Linq;

namespace SistemaVendas.Controllers
{
    public class RelatorioController : Controller
    {
        private readonly ApplicationDbContext _repository;

        public RelatorioController(ApplicationDbContext repository)
        {
            _repository = repository;
        }

        public IActionResult Grafico()
        {
            //var lista = _repository.VendaProduto
            //                       .GroupBy(x => x.CodigoProduto)
            //                       .Select(x => new GraficoViewModel()
            //                       {
            //                           CodigoProduto = x.First().CodigoProduto,
            //                           Descricao = x.First().Produto.Descricao,
            //                           TotalVendido = x.Sum(y => y.Quantidade)
            //                       }).ToList();

            //string valores = "";
            //string labels = "";
            //string cores = "";

            //var rd = new Random();

            //for (int i = 0; i < lista.Count; i++)
            //{
            //    valores += lista[i].TotalVendido.ToString() + ",";
            //    labels += "'" + lista[i].Descricao.ToString() + "',";
            //    cores += "'" + string.Format("#{0:X6}", rd.Next(i, i * 2)) + "',";
            //}

            //ViewBag.Valores = valores;
            //ViewBag.Labels = labels;
            //ViewBag.Cores = cores;

            return View();
        }
    }
}
