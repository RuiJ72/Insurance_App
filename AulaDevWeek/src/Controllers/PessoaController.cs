using Microsoft.AspNetCore.Mvc;
using src.Models;
using Microsoft.EntityFrameworkCore;
using src.Persistence;

namespace src.Controllers
{

    [ApiController]
    [Route("[Controller]")] // Get localhost:7165/
    public class PessoaController : ControllerBase
    {   
        private DatabaseContext _context { get; set; }

        public PessoaController(DatabaseContext context)
        {
            this._context = context;
        }

        //private string id;

        [HttpGet]
        public List<Pessoa> Get()
        {
            //Pessoa pessoa = new Pessoa("Rui", 50, "12345678");
            //Contrato novoContrato = new Contrato("abc123", 50.63);

            //pessoa.contratos.Add(novoContrato);


           return _context.Pessoas.Include(p => p.contratos).ToList();
            //return pessoa;
        }

        [HttpPost]
        public Pessoa Post([FromBody]Pessoa pessoa)
        {   
            _context.Pessoas.Add(pessoa);
            _context.SaveChanges();
            
            return pessoa;
        }

        [HttpPut("{id}")]
        public string Update([FromRoute]int id, [FromBody]Pessoa pessoa)
        {
            _context.Pessoas.Update(pessoa);
            _context.SaveChanges();

            return " Dados do id " + id + " atualizados ";
        }

        [HttpDelete("{id}")]
        public string Delete([FromRoute]int id, [FromBody]Pessoa pessoa)
        {
            var result = _context.Pessoas.SingleOrDefault(e => e.Id == id);

            _context.Pessoas.Remove(result);
            _context.SaveChanges();
            return " deletadada a pessoa com o id " + id;
        }
    }
}
