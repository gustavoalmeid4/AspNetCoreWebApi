using Microsoft.AspNetCore.Mvc;
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

        public List<Aluno> Alunos = new List<Aluno>()
        {
            new Aluno()
            {
                Id = 1,
                Nome = "Gustavo",
                Sobrenome = "Almeida",
                Telefone = "40028922",
            },
            new Aluno()
            {
                Id = 2,
                Nome = "Almeida",
                Sobrenome = "Cabuloso",
                Telefone = "123456",
            },
            new Aluno()
            {
                Id = 3,
                Nome = "Cabuloso",
                Sobrenome = "Maladeza",
                Telefone = "1234567",
            }
        };

        public AlunoController(){ }

        // GET: api/<AlunoController>http://localhost:52349/api/aluno
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(Alunos);
        }

        [HttpGet("byId/{id}")]
        public IActionResult GetById(int id)
        {
            var aluno = Alunos.FirstOrDefault(a => a.Id == id);
            if (aluno == null) return BadRequest("O Aluno não foi encontrado.");
            return Ok(aluno);
        }

        [HttpGet("byName")]
        public IActionResult GetByNome(string nome , string sobrenome)
        {
            var aluno = Alunos.FirstOrDefault(a => 
            a.Nome.Contains(nome) && a.Sobrenome.Contains(sobrenome));
            if (aluno == null) return BadRequest("O Aluno não foi encontrado.");
            return Ok(aluno);
        }

        [HttpPost]
        public IActionResult Post(Aluno aluno)
        {
            return Ok(aluno);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id ,Aluno aluno)
        {
            return Ok(aluno);
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Aluno aluno)
        {
            return Ok(aluno);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id , Aluno aluno)
        {
            return Ok(aluno);
        }

    }
}
