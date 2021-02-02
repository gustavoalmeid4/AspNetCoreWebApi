using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartScholl.Data
{
    public class Repository : IRepository
    {
        private readonly DataContext _dataContext;
        public Repository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public void Add<T>(T entity) where T : class
        {
            _dataContext.Add(entity);
        }
        public void Update<T>(T entity) where T : class
        {
            _dataContext.Update(entity);     
        }

        public void Delete<T>(T entity) where T : class
        {
            _dataContext.Remove(entity);
        }

        public bool SaveChanges()
        {
            return (_dataContext.SaveChanges() > 0 );
        }

    }
}
