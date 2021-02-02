﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartScholl.Data;
using SmartScholl.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SmartScholl.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessorController : ControllerBase
    {
        private readonly DataContext _dataContext;
        private readonly IRepository _repo;

        public ProfessorController(DataContext dataContext , 
                                    IRepository repo)
        {
            _dataContext = dataContext;
            _repo = repo;
        }

        // GET: api/<ProfessorController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_dataContext.Professores);
        }

        // GET api/<ProfessorController>/5
        [HttpGet("byId/{id}")]
        public IActionResult GetById(int id)
        {
            var professor = _dataContext.Professores.FirstOrDefault(a => a.Id == id);
            if (professor == null) return BadRequest("O Aluno não foi encontrado.");
            return Ok(professor);
            
        }

        [HttpGet("byName")]
        public IActionResult GetByNome(string nome, string sobrenome)
        {
            var professor = _dataContext.Professores.FirstOrDefault(a =>
            a.Nome.Contains(nome));
            if (professor == null) return BadRequest("O Aluno não foi encontrado.");
            return Ok(professor);
        }

        // POST api/<ProfessorController>
        [HttpPost]
        public IActionResult Post(Professor professor)
        {
            _repo.Add(professor);
            if (_repo.SaveChanges())
            {
                return Ok(professor);
            }
            return BadRequest("Não foi possivel cadastrar o aluno!");
            
        }

        // PUT api/<ProfessorController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, Professor professor)
        {
            var prof = _dataContext.Professores.AsNoTracking().FirstOrDefault(a => a.Id == id);
            if (prof == null) return BadRequest("Aluno não encontrado");

            _repo.Update(professor);
            if (_repo.SaveChanges())
            {
                return Ok($"Professor : {professor} /n cadastrado");
            }
            return BadRequest("Não foi possivel atualizar o aluno");
        }

        // DELETE api/<ProfessorController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var professor = _dataContext.Professores.AsNoTracking().FirstOrDefault(async => async.Id == id);
            if (professor == null) return BadRequest("Aluno não encontrado");
           
            _repo.Delete(professor);
            if (_repo.SaveChanges())
            {
                return Ok($"SETA BANIDO!");
            }
            return BadRequest("Não foi possivel deletar o professor");

        }
    }
}
