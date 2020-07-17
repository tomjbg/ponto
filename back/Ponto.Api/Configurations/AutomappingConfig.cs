using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Ponto.Api.Dto;
using Ponto.Domain.Models;

namespace Ponto.Api.Configurations
{
    public class AutomappingConfig : Profile
    {
        public AutomappingConfig()
        {

            CreateMap<Empresa, EmpresaDto>().ReverseMap();
            CreateMap<EnderecoEmpresa, EnderecoEmpresaDto>().ReverseMap();
            CreateMap<Funcionario, FuncionarioDto>().ReverseMap();

        }
    }
}
