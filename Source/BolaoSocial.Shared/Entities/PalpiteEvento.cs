﻿using System.Collections.Generic;

namespace BolaoSocial.Shared.Entities
{
    public class PalpiteEvento : Base
    {
        public Evento Evento { get; set; }

        public IEnumerable<PalpiteParticipante> Palpites { get; set; }
    }
}
