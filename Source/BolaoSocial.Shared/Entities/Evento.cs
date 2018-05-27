using System;
using System.Collections.Generic;

namespace BolaoSocial.Shared.Entities
{
    public class Evento : Base
    {
        public string Observacao { get; set; }

        public Evento EventoPai { get; set; }

        public EventoType Tipo { get; set; }

        public Competicao Competicao { get; set; }

        public IEnumerable<EventoParticipante> Participantes { get; set; }

        public IEnumerable<EventoAgrupamento> Agrupamentos { get; set; }

        public bool PermiteSubEvento { get; set; }

        public string Localizacao { get; set; }

        public DateTime Horario { get; set; }

        public bool Cancelado { get; set; }

        public bool Processado { get; set; }
    }
}
