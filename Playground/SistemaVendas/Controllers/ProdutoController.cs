using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SistemaVendas.DAL;
using SistemaVendas.Entidades;
using SistemaVendas.Models;
using System.Collections.Generic;
using System.Linq;

namespace SistemaVendas.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly ApplicationDbContext _repository;

        public ProdutoController(ApplicationDbContext repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            var lista = _repository.Produto.Include(x => x.Categoria).ToList();
            //lista.ForEach(x =>
            //{
            //    x.Categoria = _repository.Categoria.Where(c => c.Codigo == x.CodigoCategoria).FirstOrDefault();
            //});
            _repository.Dispose();
            return View(lista);
        }

        [HttpGet]
        public IActionResult Cadastro(int? id)
        {
            var model = new ProdutoViewModel
            {
                ListaCategorias = ListaCategorias()
            };

            if (id != null)
            {
                var entidade = _repository.Produto.Where(x => x.Codigo == id).FirstOrDefault();
                model.Codigo = entidade.Codigo;
                model.Descricao = entidade.Descricao;
                model.Quantidade = entidade.Quantidade;
                model.Valor = entidade.Valor;
                model.CodigoCategoria = entidade.CodigoCategoria;
            }

            return View(model);
        }

        private IEnumerable<SelectListItem> ListaCategorias()
        {
            List<SelectListItem> lista = new();

            lista.Add(new SelectListItem()
            {
                Value = string.Empty,
                Text = string.Empty
            });

            foreach (var item in _repository.Categoria.ToList())
            {
                lista.Add(new SelectListItem()
                {
                    Value = item.Codigo.ToString(),
                    Text = item.Descricao.ToString()
                });
            }

            return lista;
        }

        [HttpPost]
        public IActionResult Cadastro(ProdutoViewModel entidade)
        {
            if (ModelState.IsValid)
            {
                var produto = new Produto()
                {
                    Codigo = (entidade.Codigo != null) ? (int)entidade.Codigo : 0,
                    Descricao = entidade.Descricao,
                    Quantidade = entidade.Quantidade,
                    Valor = entidade.Valor,
                    CodigoCategoria = (entidade.CodigoCategoria != null) ? (int)entidade.CodigoCategoria : 0
                };

                if (entidade.Codigo == null)
                    _repository.Produto.Add(produto);
                else
                    _repository.Entry(produto).State = EntityState.Modified;

                _repository.SaveChanges();
            }
            else
            {
                entidade.ListaCategorias = ListaCategorias();
                return View(entidade);
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Excluir(int id)
        {
            var entidade = new Produto() { Codigo = id };
            _repository.Attach(entidade);
            _repository.Remove(entidade);
            _repository.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
