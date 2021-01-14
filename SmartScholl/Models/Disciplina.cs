using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartScholl.Models
{
    public class Disciplina
    {

        public Disciplina() { }

        public Disciplina(string nome, int id, int professorId)
        {
            Nome = nome;
            Id = id;
            ProfessorId = professorId;
            
        }

        public string Nome { get; set; }

        public int Id { get; set; }

        public int ProfessorId { get; set; }

        public Professor Professor { get; set; }

        public IEnumerable<AlunoDisciplina> AlunoDisciplinas { get; set; }


    }
}
