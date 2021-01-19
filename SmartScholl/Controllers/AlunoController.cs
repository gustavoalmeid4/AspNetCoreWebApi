using Microsoft.AspNetCore.Mvc;
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
        private readonly DataContext _dataContext;

        public AlunoController(DataContext dataContext )
        {
            _dataContext = dataContext;
        }




        // GET: api/<AlunoController>http://localhost:52349/api/aluno
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_dataContext.Alunos);
        }

        [HttpGet("byId/{id}")]
        public IActionResult GetById(int id)
        {
            var aluno = _dataContext.Alunos.FirstOrDefault(a => a.Id == id);
            if (aluno == null) return BadRequest("O Aluno não foi encontrado.");
            return Ok(aluno);
        }

        [HttpGet("byName")]
        public IActionResult GetByNome(string nome , string sobrenome)
        {
            var aluno = _dataContext.Alunos.FirstOrDefault(a => 
            a.Nome.Contains(nome) && a.Sobrenome.Contains(sobrenome));
            if (aluno == null) return BadRequest("O Aluno não foi encontrado.");
            return Ok(aluno);
        }

        [HttpPost]
        public IActionResult Post(Aluno aluno)
        {
            _dataContext.Add(aluno);
            _dataContext.SaveChanges();
            return Ok(aluno);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id ,Aluno aluno)
        {
            var al = _dataContext.Alunos.AsNoTracking().FirstOrDefault(a => a.Id == id);
            if (al == null) return BadRequest("Aluno não encontrado");
            _dataContext.Update(aluno);
            _dataContext.SaveChanges();
            return Ok(aluno);
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Aluno aluno)
        {
            var al = _dataContext.Alunos.AsNoTracking().FirstOrDefault(a => a.Id == id);
            if (al == null) return BadRequest("Aluno não encontrado");
            _dataContext.Update(aluno);
            _dataContext.SaveChanges();
            return Ok(aluno);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var aluno = _dataContext.Alunos.FirstOrDefault(a => a.Id == id);
            if (aluno == null) return BadRequest("Aluno não encontrado");               
            _dataContext.Remove(aluno);
            _dataContext.SaveChanges();
            return Ok(aluno);
        }

    }
}
