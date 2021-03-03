﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartScholl.Data;
using SmartScholl.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SmartScholl.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        private readonly IRepository _repo;

        public AlunoController(IRepository repo)
        {
            _repo = repo;
        }

       


        // GET: api/<AlunoController>http://localhost:52349/api/aluno
        [HttpGet]
        public IActionResult Get()
        {
            var result = _repo.GetAllAlunos(true);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var aluno = _repo.GetAlunoByID(id, false);
            if (aluno == null) return BadRequest("O Aluno não foi encontrado.");
            return Ok(aluno);
        }


        [HttpPost]
        public IActionResult Post(Aluno aluno)
        {
            _repo.Add(aluno);
           if( _repo.SaveChanges())
            {
                return Ok($"Aluno : {aluno} cadastrado");
            }
            return BadRequest("Não foi possivel cadastrar o aluno");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id ,Aluno aluno)
        {
            var al = _repo.GetAlunoByID(id, false);
            if (al == null) return BadRequest("Aluno não encontrado");

            _repo.Update(aluno);
            if (_repo.SaveChanges())
            {
                return Ok($"Aluno : {aluno} atualizado");
            }
            return BadRequest("Não foi possivel atualizar o aluno");
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Aluno aluno)
        {
            var al = _repo.GetAlunoByID(id, false);
            if (al == null) return BadRequest("Aluno não encontrado");

            _repo.Update(aluno);
            if (_repo.SaveChanges())
            {
                return Ok($"Aluno : {aluno} atualizado");
            }
            return BadRequest("Não foi possivel atualizar o aluno");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var aluno = _repo.GetAlunoByID(id, false);
            if (aluno == null) return BadRequest("Aluno não encontrado");

            _repo.Delete(aluno);
            if (_repo.SaveChanges())
            {
                return Ok($"Aluno : {aluno.Nome} deletado!");
            }
            return BadRequest("Não foi possivel atualizar o aluno");
        }

    }
}
