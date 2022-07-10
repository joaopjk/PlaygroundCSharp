using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaVendas.DAL;
using SistemaVendas.Entidades;
using SistemaVendas.Models;
using System.Linq;

namespace SistemaVendas.Controllers
{
    public class CategoriaController : Controller
    {
        protected ApplicationDbContext _repository;

        public CategoriaController(ApplicationDbContext repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            var lista = _repository.Categoria.ToList();
            _repository.Dispose();
            return View(lista);
        }

        [HttpGet]
        public IActionResult Cadastro(int? id)
        {
            var categoriaViewModel = new CategoriaViewModel();

            if (id != null)
            {
                var entidade = _repository.Categoria.Where(x => x.Codigo == id).FirstOrDefault();
                categoriaViewModel.Codigo = entidade.Codigo;
                categoriaViewModel.Descricao = entidade.Descricao;
            }

            return View(categoriaViewModel);
        }

        [HttpPost]
        public IActionResult Cadastro(CategoriaViewModel entidade)
        {
            if (ModelState.IsValid)
            {
                var categoria = new Categoria()
                {
                    Codigo = (entidade.Codigo != null) ? (int)entidade.Codigo : 0,
                    Descricao = entidade.Descricao
                };

                if (entidade.Codigo == null)
                {
                    _repository.Add(categoria);
                }
                else
                {
                    _repository.Entry(categoria).State = EntityState.Modified;
                }

                _repository.SaveChanges();
            }
            else
            {
                return View(entidade);
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Excluir(int id)
        {
            var entidade = new Categoria() { Codigo = id };
            _repository.Attach(entidade);
            _repository.Remove(entidade);
            _repository.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
