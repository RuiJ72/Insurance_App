using System.Collections.Generic;


namespace src.Models
{
    public class Pessoa
    {

        public Pessoa()
        {
            this.Nome = "template";
            this.Idade = 0;
            this.contratos = new List<Contrato>();
            this.Ativo = true;
        }

        public Pessoa(string nome, int idade, string Cpf)
        {
            this.Nome = nome;
            this.Idade = idade;
            this.Cpf = Cpf;
            this.contratos = new List<Contrato>();
            this.Ativo = true;
            
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
        public string? Cpf { get; set; }
        public bool Ativo { get; set; }
        public List<Contrato> contratos { get; set; }
    }
}
