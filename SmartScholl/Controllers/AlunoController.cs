using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartScholl.Data;
using SmartScholl.Dtos;
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
        private readonly IMapper _mapper;

        public AlunoController(IRepository repo , IMapper mapper)
        {
            _repo = repo;
            this._mapper = mapper;
        }

       


        // GET: api/<AlunoController>http://localhost:52349/api/aluno
        [HttpGet]
        public IActionResult Get()
        {
            var alunos = _repo.GetAllAlunos(true);
         
            return Ok(_mapper.Map<IEnumerable<AlunoDto>>(alunos));
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var aluno = _repo.GetAlunoByID(id, false);
            if (aluno == null) return BadRequest("O Aluno não foi encontrado.");

            var alunoDto = _mapper.Map<AlunoDto>(aluno);
            return Ok(alunoDto);
        }


        [HttpPost]
        public IActionResult Post(AlunoDto model)
        {

            var aluno = _mapper.Map<Aluno>(model);
            _repo.Add(aluno);
           if( _repo.SaveChanges())
            {
                return Created($"/api/aluno/{model.Id} ", _mapper.Map<AlunoDto>(aluno));
            }
            return BadRequest("Não foi possivel cadastrar o aluno");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id ,AlunoDto model)
        {
            var aluno = _repo.GetAlunoByID(id, false);
            if (aluno == null) return BadRequest("Aluno não encontrado");

            _mapper.Map(model , aluno);

            _repo.Update(aluno);
            if (_repo.SaveChanges())
            {
                return Created($"/api/aluno/{model.Id} ", _mapper.Map<AlunoDto>(aluno));
            }
            return BadRequest("Não foi possivel atualizar o aluno");
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, AlunoDto model)
        {
            var aluno = _repo.GetAlunoByID(id);
            if (aluno == null) return BadRequest("Aluno não encontrado");

            _repo.Update(aluno);
            if (_repo.SaveChanges())
            {
                return Created($"/api/aluno/{model.Id} ", _mapper.Map<AlunoDto>(aluno));
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
