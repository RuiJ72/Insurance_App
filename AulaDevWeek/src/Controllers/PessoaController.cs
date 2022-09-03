using Microsoft.AspNetCore.Mvc;
using src.Models;

namespace src.Controllers
{

    [ApiController]
    [Route("[Controller]")] // Get localhost:7165/
    public class PessoaController : ControllerBase
    {
        private string id;

        [HttpGet]
        public Pessoa Get()
        {
            Pessoa pessoa = new Pessoa("Rui", 50, "12345678");
            Contrato novoContrato = new Contrato("abc123", 50.63);
            
            pessoa.contratos.Add(novoContrato);
            

            return pessoa;
        }

        [HttpPost]
        public Pessoa Post([FromBody]Pessoa pessoa)
        {
            return pessoa;
        }

        [HttpPut("{id}")]
        public string Update([FromRoute]int id, [FromBody]Pessoa pessoa)
        {
            Console.WriteLine(id);
            Console.WriteLine(pessoa);
            return " Dados do id " + id + " atualizados ";
        }

        [HttpDelete("{id}")]
        public string Delete([FromRoute]int id)
        {
            return " deletadada a pessoa com o id " + id;
        }
    }
}
