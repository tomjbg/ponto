using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ponto.Api.Controllers;
using Ponto.Api.Dto;
using Ponto.Domain.Interfaces;
using Ponto.Api.Configurations;
using Ponto.Domain.Models;

namespace Ponto.Api.V1.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    public class FuncionariosController : MainController
    {
        private readonly IMapper _mapper;
        private readonly IFuncionarioRepository _funcionarioRepository;
        private readonly IFuncionarioService _funcionarioService;

        public FuncionariosController(IMapper mapper,
                                      INotificador notificador,
                                      IFuncionarioRepository funcionarioRepository, 
                                      IFuncionarioService funcionarioService) : base(notificador)
        {
            _mapper = mapper;
            _funcionarioRepository = funcionarioRepository;
            _funcionarioService = funcionarioService;
        }

        //[AuthorizeClaims("Funcionarios", "Ler")]
        [HttpGet]
        public async Task<ActionResult<IList<FuncionarioDto>>> obterTodos()
        {

           IList<FuncionarioDto> funcionarios = _mapper.Map<IList<FuncionarioDto>>(await _funcionarioRepository.ObterTodos());

            return CustomResponse(funcionarios);
        }

        //[AuthorizeClaims("Funcionarios", "Adicionar")]
        [HttpPost]        
        public async Task<ActionResult<FuncionarioDto>> Adicionar(FuncionarioDto funcionarioDto)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState); // Notifications do ModelState

            if (funcionarioDto.Invalid) NotificarErros(funcionarioDto.Notifications.ToList()); // Notificações do Contrato da Dto

            Funcionario funcionario = _mapper.Map<Funcionario>(funcionarioDto);

            if (!await _funcionarioService.Adicionar(funcionario)) NotificarErros(funcionario.Notifications.ToList());
            
            return CustomResponse(funcionarioDto);
        }


    }
}