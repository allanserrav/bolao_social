using System.Collections.Generic;

namespace BolaoSocial.Shared.Entities
{
    public class Agrupamento : Base
    {
        public string Nome { get; set; }

        public IEnumerable<EventoAgrupamento> Eventos { get; set; }
    }
}
