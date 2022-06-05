using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SistemaVendas.DAL;
using SistemaVendas.Entidades;
using SistemaVendas.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SistemaVendas.Controllers
{
    public class VendaController : Controller
    {
        private readonly ApplicationDbContext _repository;

        public VendaController(ApplicationDbContext repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            var lista = _repository.Venda.ToList();
            _repository.Dispose();
            return View(lista);
        }

        [HttpGet]
        public IActionResult Cadastro(int? id)
        {
            var model = new VendaViewModel
            {
                ListaClientes = ListaClientes(),
                ListaProdutos = ListaProdutos()
            };

            if (id != null)
            {
                var entidade = _repository.Venda.Where(x => x.Codigo == id).FirstOrDefault();
                model.Codigo = entidade.Codigo;
                model.Data = Convert.ToDateTime(entidade.Data);
                model.CodigoCliente = entidade.Codigo;
                model.Total = entidade.Total;
            }

            return View(model);
        }

        private IEnumerable<SelectListItem> ListaProdutos()
        {
            List<SelectListItem> lista = new();

            lista.Add(new SelectListItem()
            {
                Value = string.Empty,
                Text = string.Empty
            });

            foreach (var item in _repository.Produto.ToList())
            {
                lista.Add(new SelectListItem()
                {
                    Value = item.Codigo.ToString(),
                    Text = item.Descricao.ToString()
                });
            }

            return lista;
        }

        private IEnumerable<SelectListItem> ListaClientes()
        {
            List<SelectListItem> lista = new();

            lista.Add(new SelectListItem()
            {
                Value = string.Empty,
                Text = string.Empty
            });

            foreach (var item in _repository.Cliente.ToList())
            {
                lista.Add(new SelectListItem()
                {
                    Value = item.Codigo.ToString(),
                    Text = item.Nome.ToString()
                });
            }

            return lista;
        }

        [HttpPost]
        public IActionResult Cadastro(VendaViewModel entidade)
        {
            if (ModelState.IsValid)
            {
                var venda = new Venda()
                {
                    Codigo = (entidade.Codigo != null) ? (int)entidade.Codigo : 0,
                    Data = entidade.Data.ToString(),
                    Total = entidade.Total,
                    CodigoCliente = (entidade.CodigoCliente != null) ? (int)entidade.CodigoCliente : 0,
                    Produtos = JsonConvert.DeserializeObject<ICollection<VendaProduto>>(entidade.JsonProdutos)
                };

                if (entidade.Codigo == null)
                    _repository.Venda.Add(venda);
                else
                    _repository.Entry(venda).State = EntityState.Modified;

                _repository.SaveChanges();
            }
            else
            {
                entidade.ListaProdutos = ListaProdutos();
                entidade.ListaClientes = ListaClientes();
                return View(entidade);
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Excluir(int id)
        {
            var entidade = new Venda() { Codigo = id };
            _repository.Attach(entidade);
            _repository.Remove(entidade);
            _repository.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet("LerValorProduto/{id}")]
        public decimal LerValorProduto(int id)
        {
            return _repository.Produto.Where(x => x.Codigo == id).FirstOrDefault().Valor;
        }
    }
}
