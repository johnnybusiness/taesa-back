using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using gestor.Domain;
using gestor.Persistance;
using GestorGaleria.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace gestor.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
          private readonly DataContext _context;
        public UsuarioController(DataContext context)
        {
            _context = context;
        }
       [HttpGet]

        public IEnumerable<Usuario> Get()
        {
            return _context.Usuarios;
        }

        [HttpGet("{id}")]
        public Usuario GetById(int id)
        {
            return _context.Usuarios.FirstOrDefault(usuario => usuario.Id == id);
        }

        [HttpPost]

       
        public IActionResult Post(Usuario usuario)
        {
            // return "value";
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();

            return Ok(usuario);

        }
        

        [HttpPut("{id}")]

        public IActionResult Put(Usuario usuario)
        {
            _context.Usuarios.Update(usuario);
            _context.SaveChanges();
            return Ok(usuario);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var usuario = _context.Usuarios.FirstOrDefault(Usuario => Usuario.Id == id);
            _context.Usuarios.Remove(usuario);
            _context.SaveChanges();
            return Ok(usuario);
        }
    }
}