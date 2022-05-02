using eCommerce.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace eCommerce.API.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private static List<Usuario> _db = new()
        {
            new Usuario()
            {
                Id = 1,
                Nome = "João Cícero Vicente Sousa",
                Email = "joao@email.com"
            },
            new Usuario()
            {
                Id = 2,
                Nome = "Jucemie Santos",
                Email = "jucemie@email.com"
            },
            new Usuario()
            {
                Id = 3,
                Nome = "Francici Santos",
                Email = "francini@email.com"
            }
        };

        public async Task Delete(int id)
        {
            _db.Remove(_db.First(x => x.Id == id));
        }

        public async Task<List<Usuario>> Get()
        {
            return _db;
        }

        public async Task<Usuario> Get(int id)
        {
            return _db.FirstOrDefault(x => x.Id == id);
        }

        public async Task Insert(Usuario usuario)
        {
            _db.Add(usuario);
        }

        public async Task Update(Usuario usuario)
        {
            _db.Remove(_db.First(x => x.Id == usuario.Id));

            _db.Add(usuario);
        }
    }
}
