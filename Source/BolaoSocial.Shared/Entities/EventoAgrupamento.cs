using System;
using System.Collections.Generic;
using System.Text;

namespace BolaoSocial.Shared.Entities
{
    public class EventoAgrupamento : Base
    {
        public Evento Evento { get; set; }

        public Agrupamento Agrupamento { get; set; }

        public int Ordem { get; set; }
    }
}
