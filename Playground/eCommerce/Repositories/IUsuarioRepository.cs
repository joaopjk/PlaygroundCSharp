using eCommerce.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eCommerce.API.Repositories
{
    public interface IUsuarioRepository
    {
        Task<List<Usuario>> Get();
        Task<Usuario> Get(int id);
        Task Insert(Usuario usuario);
        Task Update(Usuario usuario);
        Task Delete(int id);
    }
}
