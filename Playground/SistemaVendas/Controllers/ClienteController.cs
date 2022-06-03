using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaVendas.DAL;
using SistemaVendas.Entidades;
using SistemaVendas.Models;
using System.Linq;

namespace SistemaVendas.Controllers
{
    public class ClienteController : Controller
    {
        private readonly ApplicationDbContext _repository;

        public ClienteController(ApplicationDbContext repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            var lista = _repository.Cliente.ToList();
            _repository.Dispose();
            return View(lista);
        }

        [HttpGet]
        public IActionResult Cadastro(int? id)
        {
            var model = new ClienteViewModel();

            if (id != null)
            {
                var entidade = _repository.Cliente.Where(x => x.Codigo == id).FirstOrDefault();
                model.Codigo = entidade.Codigo;
                model.Nome = entidade.Nome;
                model.Email = entidade.Email;
                model.CNPJ_CPF = entidade.CNPJ_CPF;
                model.Celular = entidade.Celular;
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult Cadastro(ClienteViewModel entidade)
        {
            if (ModelState.IsValid)
            {
                var cliente = new Cliente()
                {
                    Codigo = (entidade.Codigo != null) ? (int)entidade.Codigo : 0,
                    Nome = entidade.Nome,
                    Email = entidade.Email,
                    CNPJ_CPF = entidade.CNPJ_CPF,
                    Celular = entidade.Celular
                };

                if (entidade.Codigo == null)
                    _repository.Cliente.Add(cliente);
                else
                    _repository.Entry(cliente).State = EntityState.Modified;

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
            var entidade = new Cliente() { Codigo = id };
            _repository.Attach(entidade);
            _repository.Remove(entidade);
            _repository.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
