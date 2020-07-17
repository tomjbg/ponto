using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace Ponto.Domain.Models.Validations
{
    public class EmpresaValidation : AbstractValidator<Empresa>
    {
        public EmpresaValidation()
        {
            RuleFor(f => f.RazaoSocial)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(3, 100).WithMessage("O campo {propertyname} deve ter entre 3 e 100 caracteres");

            RuleFor(f => f.NomeFantasia)
                .Length(3, 150).WithMessage("O campo {propertyname} deve ter entre 3 e 150 caracteres");

            RuleFor(f => f.CNPJ)
                .NotEmpty().WithMessage("O campo {PropertyName} deve ser fornecido");

        }
    }
}
