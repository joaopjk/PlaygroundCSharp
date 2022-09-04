using System;
using System.Collections.Generic;

namespace Repositories
{
    public class RepositorioEspecifico : IRepository
    {
        public void Add(RepositorioEspecifico item)
        {
            throw new NotImplementedException();
        }

        public void Delete(RepositorioEspecifico item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<RepositorioEspecifico> GetAll()
        {
            throw new NotImplementedException();
        }

        public RepositorioEspecifico GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(RepositorioEspecifico item)
        {
            throw new NotImplementedException();
        }
    }

    public interface IRepository
    {
        IEnumerable<RepositorioEspecifico> GetAll();
        RepositorioEspecifico GetById(int id);
        void Add(RepositorioEspecifico item);
        void Update(RepositorioEspecifico item);
        void Delete(RepositorioEspecifico item);
    }
}
