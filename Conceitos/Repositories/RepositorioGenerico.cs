using System;
using System.Collections.Generic;

namespace Repositories
{
    public class RepositorioGenerico : IRepository<RepositorioGenerico>
    {
        public void Add(RepositorioGenerico item)
        {
            throw new NotImplementedException();
        }

        public void Delete(RepositorioGenerico item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<RepositorioGenerico> GetAll()
        {
            throw new NotImplementedException();
        }

        public RepositorioGenerico GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(RepositorioGenerico item)
        {
            throw new NotImplementedException();
        }
    }

    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        void Add(T item);
        void Update(T item);
        void Delete(T item);
    }
}
