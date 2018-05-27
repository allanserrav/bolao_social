﻿using System.Collections.Generic;
using System.Linq;

namespace BolaoSocial.Shared.Models
{
    public class Competicao : Base
    {
        public string Nome { get; set; }

        public IEnumerable<Evento> Eventos { get; set; }

        public EventoType EventoTipo { get; set; }
    }
}
