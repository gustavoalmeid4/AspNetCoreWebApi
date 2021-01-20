using System;
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
        public ProfessorController(DataContext dataContext)
        {
            _dataContext = dataContext;
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
            _dataContext.Add(professor);
            _dataContext.SaveChanges();
            return Ok(professor);

        }

        // PUT api/<ProfessorController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, Professor professor)
        {
            var prof = _dataContext.Professores.AsNoTracking().FirstOrDefault(a => a.Id == id);
            if (prof == null) return BadRequest("Aluno não encontrado");
            _dataContext.Update(prof);
            _dataContext.SaveChanges();
            return Ok(prof);
        }

        // DELETE api/<ProfessorController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var professor = _dataContext.Professores.AsNoTracking().FirstOrDefault(async => async.Id == id);
            if (professor == null) return BadRequest("Aluno não encontrado");
            _dataContext.Remove(professor);
            _dataContext.SaveChanges();
            return Ok(professor);
            
        }
    }
}
