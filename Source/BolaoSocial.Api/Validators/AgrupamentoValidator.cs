using BolaoSocial.Shared.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BolaoSocial.Api.Validators
{
    public class AgrupamentoValidator : AbstractValidator<Agrupamento>
    {
        public AgrupamentoValidator()
        {
            RuleFor(reg => reg.Nome)
                .NotEmpty()
                .When(a => a.Id <= 0)
                .WithMessage("Nome não informado");
        }
    }
}
