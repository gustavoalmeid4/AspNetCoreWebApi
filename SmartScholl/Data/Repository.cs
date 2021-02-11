using SmartScholl.Models;
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

        public Aluno[] GetAllAlunos()
        {
            throw new NotImplementedException();
        }

        public Aluno[] GetAllAlunosByID()
        {
            throw new NotImplementedException();
        }

        public Aluno GetAluno()
        {
            throw new NotImplementedException();
        }

        public Professor[] GetAllProfessores()
        {
            throw new NotImplementedException();
        }

        public Professor[] GetAllProfessoresByID()
        {
            throw new NotImplementedException();
        }

        public Professor GetProfessor()
        {
            throw new NotImplementedException();
        }
    }
}
