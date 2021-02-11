using Microsoft.EntityFrameworkCore;
using SmartScholl.Models;
using System;
using System.Linq;

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
        
        Aluno[] GetAlunosByDisciplinaId(int disciplinaId, bool includeProfessor = false)
        {
            IQueryable<Aluno> query = _dataContext.Alunos;

            if (includeProfessor)
            {
                query = query.Include(a => a.AlunoDisciplinas)
                    .ThenInclude(ad => ad.Disciplina)
                    .ThenInclude(d => d.Professor);
            }
            query = query.AsNoTracking().OrderBy(a => a.Id)
                .Where(aluno => aluno.AlunoDisciplinas.Any(ad => ad.DisciplinaId == disciplinaId))

            return query.ToArray();
        }

        public Aluno[] GetAllAlunos(bool includeProfessor = false)
        {
            IQueryable<Aluno> query = _dataContext.Alunos;
            
            if (includeProfessor)
            {
                query = query.Include(a => a.AlunoDisciplinas)
                    .ThenInclude(ad => ad.Disciplina)
                    .ThenInclude(d => d.Professor);
            }
            query = query.AsNoTracking().OrderBy(a => a.Id);

            return query.ToArray();
        }

        public Aluno GetAllAlunosByID(int alunoId , bool includeProfessor = false)
        {
            IQueryable<Aluno> query = _dataContext.Alunos;

            if (includeProfessor)
            {
                query = query.Include(a => a.AlunoDisciplinas)
                    .ThenInclude(ad => ad.Disciplina)
                    .ThenInclude(d => d.Professor);
            }
            query = query.AsNoTracking()
                .OrderBy(a => a.Id)
                .Where(aluno => aluno.Id == alunoId);

            return query.FirstOrDefault();
        }

        public Aluno GetAluno()
        {
        }

        public Professor[] GetAllProfessores()
        {
        }

        public Professor[] GetAllProfessoresByID()
        {
        }

        public Professor GetProfessor()
        {
        }


    }
}
