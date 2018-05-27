namespace BolaoSocial.Shared.Models
{
    public class EventoParticipante : Base
    {
        public Participante Participante { get; set; }

        public Evento Evento { get; set; }

        public decimal Resultado { get; set; }
    }
}
