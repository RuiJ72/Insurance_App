using Microsoft.AspNetCore.Mvc;
using src.Models;
using Microsoft.EntityFrameworkCore;
using src.Persistence;
using System.Security.Cryptography.X509Certificates;
using System.Net;

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

        

        [HttpGet]
        public  ActionResult<List<Pessoa>> Get()
        {
         
            var result = _context.Pessoas.Include(p => p.contratos).ToList();
            
            if(!result.Any())
            {
                return NoContent();
            }

            return Ok(result);
            //return Ok(result);
            //return _context.Pessoas.Include(p => p.contratos).ToList();
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
        public ActionResult<Object> 
            Update([FromRoute]int id, 
            [FromBody]Pessoa pessoa)
        
        {

            _context.Pessoas.Update(pessoa);
            _context.SaveChanges();

            return Ok(new {
                msg = " Dados do id " + id + " atualizados ",
                status = HttpStatusCode.OK
            });
        }

        [HttpDelete("{id}")]
        public ActionResult<Object> 
            Delete([FromRoute] int id, 
            [FromBody] Pessoa pessoa)
        {
            var result = _context.Pessoas.SingleOrDefault(e => e.Id == id);
            if (result == null)
            {
                return BadRequest(new
                {
                    msg = "Conteúdo inexistente"

                });
            }

            _context.Pessoas.Remove(result);
            _context.SaveChanges();
            return Ok(new {
               msg = " deletada a pessoa com o id " + id
            }); 
          
        }   
    }
}
