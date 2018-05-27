using BolaoSocial.Shared.Contracts;
using System;

namespace BolaoSocial.Shared.Models
{
    public class Agrupamento : Base
    {
        public string Nome { get; set; }

        public Evento Evento { get; set; }
    }
}
