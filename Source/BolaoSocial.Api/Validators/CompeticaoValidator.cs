using BolaoSocial.Shared.Entities;
using FluentValidation;
using FluentValidation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BolaoSocial.Api.Validators
{
    public class CompeticaoValidator : AbstractValidator<Competicao>
    {
        public CompeticaoValidator()
        {
            RuleFor(reg => reg.Nome).NotEmpty().WithMessage("Nome não informado");
            RuleFor(reg => reg.EventoTipo)
                .SetValidator(new EnumValidator<EventoType>());
        }
    }

    public class EnumValidator<TEnum> : PropertyValidator
    {
        public const string ERROR_MESSAGE = "Seleção não é válida";

        public EnumValidator() : base(ERROR_MESSAGE)
        {
        }

        protected override bool IsValid(PropertyValidatorContext context)
        {
            var valorEnum = (byte)Enum.Parse(typeof(TEnum), context.PropertyValue.ToString());
            if(valorEnum == 0)
            {
                return false;
            }
            else if(!Enum.IsDefined(typeof(TEnum), valorEnum))
            {
                return false;
            }
            return true;
        }
    }
}
