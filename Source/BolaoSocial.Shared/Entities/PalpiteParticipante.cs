namespace BolaoSocial.Shared.Entities
{
    public class PalpiteParticipante : Base
    {
        public EventoParticipante Participante { get; set; }

        public decimal PalpiteValor { get; set; }

        public RegraAcerto Acerto { get; set; }
    }
}
