using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ponto.Domain.Interfaces;
using Ponto.Domain.Notificacoes;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Ponto.Domain.Models;
using FluentValidator;

namespace Ponto.Api.Controllers
{
    
    [ApiController]
    public abstract class MainController : ControllerBase
    {
        private readonly INotificador _notificador;

        protected MainController(INotificador notificador)
        {
            _notificador = notificador;
        }

        protected ActionResult CustomResponse(object result = null)
        {
            if (!_notificador.TemNotificacoes())
            {
                return Ok(new
                {
                    success = true,
                    data = result
                });
            }
            
            return BadRequest(new
            {
                success = false,
                errors = _notificador.ObterNotificacoes()
            });

        }

        protected ActionResult CustomResponse(ModelStateDictionary modelstate)
        {
            var erros = modelstate.Values.SelectMany(e => e.Errors);
            foreach (var err in erros)
            {
                var errorMsg = (err.Exception == null) ? err.ErrorMessage : err.Exception.Message;
                NotificarErro(errorMsg);
            }

            return CustomResponse();
        }

        protected void NotificarErro(string mensagem)
        {
            _notificador.AddNotificacao(new Notificacao(mensagem));
        }

        protected void NotificarErros(List<Notification> notifications)
        {
            notifications.ForEach(n => _notificador
                                    .AddNotificacao(new Notificacao(n.Message)));
        }

    }
}