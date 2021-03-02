using SmartScholl.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartScholl.Data
{
    public interface IRepository
    {
        void Add<T>(T entity ) where T : class ;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        bool SaveChanges();

        //alunos
        public Aluno[] GetAlunosByDisciplinaId(int disciplinaId, bool includeProfessor = false);
        public Aluno[] GetAllAlunos(bool includeProfessor = false);
        public Aluno GetAlunoByID(int alunoId, bool includeProfessor = false);

        //professores
        public Professor[] GetAllProfessoresByID(int disciplinaId, bool includeAlunos = false);
        public Professor[] GetAllProfessores(int professorId, bool includeAluno = false);
        public Professor GetProfessorById(int professorId, bool includeAluno = false);



    }
}
