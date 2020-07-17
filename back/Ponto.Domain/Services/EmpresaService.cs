using Ponto.Domain.Interfaces;
using Ponto.Domain.Models;
using Ponto.Domain.Models.Validations;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ponto.Domain.Services
{
    public class EmpresaService : BaseService, IEmpresaService
    {
        private readonly IEmpresaRepository _empresaRepository;
        public EmpresaService(INotificador notificador, 
                              IEmpresaRepository empresaRepository) : base(notificador)
        {
            _empresaRepository = empresaRepository;
        }


        public async  Task<bool> Adicionar(Empresa empresa)
        {
            //if (!empresa.validar()) return false;
            //if (!Validar(new EmpresaValidation(), empresa)) return false;
             await _empresaRepository.Adicionar(empresa);
            return true;
        }

        public async Task<bool> Atualizar(Empresa empresa)
        {
            if (!Validar(new EmpresaValidation(), empresa)) return false;
            await _empresaRepository.Atualizar(empresa);
            return true;
        }       

        public async Task<bool> Remover(Guid Id)
        {
            if (Id != null)
                await _empresaRepository.Remover(Id);
            return true;
        }

        public void Dispose()
        {
            _empresaRepository.Dispose();
        }


    }
}
