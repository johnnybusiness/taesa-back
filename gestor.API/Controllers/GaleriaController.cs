
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using gestor.API;
using gestor.Persistance;
using GestorGaleria.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace gestor.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GaleriaController : ControllerBase
    {
        private readonly DataContext _context;
        

        public GaleriaController(DataContext context)
        {  
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Galeria> Get()
        {
            return _context.Galerias;
             
        }
        //
         [HttpGet("{id}")]
        public Galeria GetById(int id)
        {
            return _context.Galerias.FirstOrDefault(galeria => galeria.Id == id);
             
        }
        

        [HttpPost]
        public IActionResult Post(Galeria galeria)
        {
            // return "value";
            _context.Galerias.Add(galeria);
            _context.SaveChanges();
             
            return Ok(galeria);
             
        }

        [HttpPut]
        public IActionResult Put(Galeria galeria)
        {
            _context.Galerias.Update(galeria);
            _context.SaveChanges();
             
            return Ok(galeria);
        }
        

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var galeria = _context.Galerias.FirstOrDefault(galeria => galeria.Id == id);
            _context.Galerias.Remove(galeria);
            _context.SaveChanges();
            return Ok(galeria);
        }
    }
}




/*
 using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using gestor.API.Data;
using gestor.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace gestor.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GaleriaController : ControllerBase
    { 
        
        private readonly DataContext _context;

        public GaleriaController(DataContext context)
        {  
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Galeria> Get()
        {
            return _context.Galerias;
             
        }

         [HttpGet("{id}")]
        public Galeria GetById(int id)
        {
            return _context.Galerias.FirstOrDefault
            (galeria => galeria.Id == id);
             
        }
        

        [HttpPost]
        public string Post()
        {
            return "Exemplo de post";
        }

        [HttpPut("{id}")]
        public string Put(int id)
        {
            return $"Exemplo de put com id = {id}";
        }

        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            return $"Exemplo de Delete com id = {id}";
        }
    }
} 
*/