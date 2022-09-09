using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using gestor.API;
using gestor.Persistance;

namespace gestor.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TiposController : ControllerBase
    {
      
        private readonly DataContext _context;

        public TiposController(DataContext context)
        {
            _context = context;
        }
       

        [HttpGet]

        public IEnumerable<Tipos> Get()
        {
            return _context.Tipos;
        }
        [HttpGet("{id}")]
        public IEnumerable<Tipos> GetById(int id)
        {
            return _context.Tipos.Where(tipos => tipos.Id == id);
        }

        [HttpPost]

        public IActionResult Post(Tipos tipos)
        {
            // return "value";
            _context.Tipos.Add(tipos);
            _context.SaveChanges();

            return Ok(tipos);

        }
        

        [HttpPut("{id}")]
        public IActionResult Put(Tipos tipos)
        {
            _context.Tipos.Update(tipos);
            _context.SaveChanges();

            return Ok(tipos);
        }
      

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var tipos = _context.Tipos.FirstOrDefault(tipos => tipos.Id == id);
            _context.Tipos.Remove(tipos);
            _context.SaveChanges();
            return Ok(tipos);
        }
    }
}