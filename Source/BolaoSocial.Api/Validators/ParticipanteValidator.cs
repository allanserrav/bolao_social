using BolaoSocial.Shared.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BolaoSocial.Api.Validators
{
    public class ParticipanteValidator : AbstractValidator<Participante>
    {
        protected ParticipanteValidator()
        {
        }
    }
}
