using BolaoSocial.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BolaoSocial.Api.Models
{
    public class EventoModel
    {
        public string Nome { get; set; }

        public int EventoPaiId { get; set; }

        public int CompeticaoId { get; set; }

        public IEnumerable<Participante> Participantes { get; set; }

        public IEnumerable<AgrupamentoModel> Agrupamentos { get; set; }

        public bool PermiteSubEvento { get; set; }

        public string Localizacao { get; set; }

        public DateTime Horario { get; set; }
    }
}