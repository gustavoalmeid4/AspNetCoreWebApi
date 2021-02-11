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

        //ALUNOS
        Aluno[] GetAllAlunos();
        Aluno[] GetAllAlunosByID();
        Aluno GetAluno();

        //PROFESSORES
        Professor[] GetAllProfessores();
        Professor[] GetAllProfessoresByID();
        Professor GetProfessor();

    }
}
