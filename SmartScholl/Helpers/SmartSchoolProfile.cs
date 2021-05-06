using AutoMapper;
using SmartScholl.Dtos;
using SmartScholl.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartScholl.Helpers
{
    public class SmartSchoolProfile : Profile
    {
        public SmartSchoolProfile()
        {
            CreateMap<Aluno, AlunoDto>()
                .ForMember(
                dest => dest.Nome,
                opt => opt.MapFrom(src => $"{src.Nome} {src.Sobrenome}"))

                .ForMember(
                    dest => dest.Idade ,
                    opt => opt.MapFrom( src => src.DataNascimento.getCurrentAge())
                )
                ;

            CreateMap<AlunoDto, Aluno>();
            CreateMap<Aluno, AlunoRegistrarDto>().ReverseMap();

        }
    }
}
