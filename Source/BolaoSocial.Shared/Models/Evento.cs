using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BolaoSocial.Shared.Models
{
    public class Evento : Base
    {
        public string Nome { get; set; }

        public Evento EventoPai { get; set; }

        public Competicao Competicao { get; set; }

        public IEnumerable<EventoParticipante> Participantes { get; set; }

        public IEnumerable<Agrupamento> Agrupamentos { get; set; }

        public bool PermiteSubEvento { get; set; }

        public string Localizacao { get; set; }

        public DateTime Horario { get; set; }

        public bool Cancelado { get; set; }

        public bool Processado { get; set; }
    }
}
