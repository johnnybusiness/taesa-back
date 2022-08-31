using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using gestor.Domain;
using gestor.Persistance;
using Microsoft.AspNetCore.Mvc;


namespace gestor.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConcessoesController : ControllerBase
    {
        private readonly DataContext _context;
        public ConcessoesController(DataContext context)
        {
            _context = context;
        }

        
        [HttpGet]
        public IEnumerable<Concessoes> Get()
        {
            return _context.Concessoes;
             
        }

        [HttpGet("{id}")]
        public Concessoes GetById(int id)
        {
            return _context.Concessoes.FirstOrDefault(Concessoes => Concessoes.Id == id);
             
        }

        [HttpPost]

        public IActionResult Post(Concessoes concessao)
        {
            // return "value";
            _context.Concessoes.Add(concessao);
            _context.SaveChanges();

            return Ok(concessao);

        }

        [HttpPut]
        public IActionResult Put(Concessoes concessao)
        {
            _context.Concessoes.Update(concessao);
            _context.SaveChanges();

            return Ok(concessao);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var concessao = _context.Concessoes.FirstOrDefault(Concessoes => Concessoes.Id == id);
            _context.Concessoes.Remove(concessao);
            _context.SaveChanges();
            return Ok(concessao);
        }
    }
}