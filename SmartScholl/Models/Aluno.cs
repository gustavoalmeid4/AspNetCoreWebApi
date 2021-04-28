﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartScholl.Models
{
    public class Aluno
    {
        public Aluno() { }

        public Aluno(int id, int matricula, string nome, string sobrenome , string telefone, DateTime dtNascimento)
        {
            Id = id;
            Matricula = matricula;
            DataNascimento = dtNascimento;
            Nome = nome;
            Sobrenome = sobrenome;
            Telefone = telefone;
        }

        public int Id { get; set; }

        public int Matricula { get; set; }

        public string Nome { get; set; }
        

        public string Sobrenome { get; set; }

        public string Telefone { get; set; }

        public DateTime DataNascimento { get; set; }

        public DateTime? DataInicio { get; set; } = DateTime.Now;

        public DateTime? DataFim { get; set; } = null;

        public bool Ativo { get; set; } = true;

        public IEnumerable<AlunoDisciplina> AlunoDisciplinas { get; set; }

    }
}
