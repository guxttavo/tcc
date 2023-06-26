namespace Core.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Cpf { get; set; }
        public string Cep { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public int Celular { get; set; }


    }
}
