namespace BolaoSocial.Shared.Entities
{
    public class Usuario : Base
    {
        public int SegundosLoginExpirar { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
    }
}
