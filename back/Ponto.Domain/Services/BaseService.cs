using System;
using System.Collections.Generic;
using System.Text;
using Ponto.Domain.Models;
using FluentValidation;
using FluentValidation.Results;
using Ponto.Domain.Interfaces;

namespace Ponto.Domain.Services
{
    public abstract class BaseService
    {
        private readonly INotificador _notificador;

        protected BaseService(INotificador notificador)
        {
            _notificador = notificador;
        }

        public bool Validar<TV, TE>(TV validacao, TE entidade) where TV : AbstractValidator<TE> where TE : Entity
        {
            ValidationResult validationResult= validacao.Validate(entidade);

            if (!validationResult.IsValid)
            {
                foreach (ValidationFailure err in validationResult.Errors)
                {
                    _notificador.AddNotificacao(new Notificacoes.Notificacao(err.ErrorMessage));
                }
            }

            return false;
        }

    }
}
