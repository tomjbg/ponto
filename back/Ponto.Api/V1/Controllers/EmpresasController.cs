using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ponto.Api.Dto;
using Ponto.Domain.Services;
using AutoMapper;
using Ponto.Domain.Interfaces;
using Ponto.Api.Controllers;
using Ponto.Domain.Models;

namespace Ponto.Api.V1.Controllers
{
    [Route("api/[controller]")]
    public class EmpresasController : MainController
    {
        private readonly IEmpresaService _empresaService;
        private readonly IEmpresaRepository _empresaRepository;
        private readonly IMapper _mapper;


        public EmpresasController(IMapper mapper,
                                 IEmpresaRepository empresaRepository,
                                 INotificador notificador, 
                                 IEmpresaService empresaService) : base(notificador)
        {
            //_empresaService = empresaService;
            _mapper = mapper;
            _empresaRepository = empresaRepository;
            _empresaService = empresaService;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmpresaDto>>> ObterTodos()
        {
            //IEnumerable<EmpresaDto> empresas = _mapper.Map<IEnumerable<EmpresaDto>>(await _empresaRepository.ObterTodos());

            //return CustomResponse(empresas);
            var lstempresas = new List<EmpresaDto>();

            return CustomResponse(lstempresas);
        }

        [HttpGet("id:guid")]
        public async Task<ActionResult<EmpresaDto>> GetById(Guid id)
        {
            EmpresaDto empresa = _mapper.Map<EmpresaDto>(await _empresaRepository.ObterPorId(id));

            return CustomResponse(empresa);
        }

        [HttpPost]
        public async Task<ActionResult<EmpresaDto>> CadastrarEmpresa(EmpresaDto empresa)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);
            Empresa empresamap = _mapper.Map<Empresa>(empresa);
            var result = await _empresaService.Adicionar(empresamap);

            return CustomResponse(empresa);
        }

        [HttpPut]
        public async Task<ActionResult<EmpresaDto>> AtualizarEmpresa(EmpresaDto empresa)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);
            await _empresaService.Atualizar(_mapper.Map<Empresa>(empresa));

            return CustomResponse(empresa);
        }

        [HttpDelete("id:guid")]
        public async Task<ActionResult<bool>> DeletarEmpresa(Guid id)
        {
            await _empresaService.Remover(id);
            return CustomResponse();
        }




    }
}