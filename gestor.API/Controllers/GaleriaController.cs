
using System;
using System.Linq;
using System.Threading.Tasks;
using gestor.Application.Dtos;
using gestor.Persistance;
using GestorGaleria.Application.Contratos;
using GestorGaleria.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace gestor.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GaleriaController : ControllerBase
    {
        private readonly IGaleriaService _galeriaService;

        private readonly DataContext _context;
        
        public GaleriaController(IGaleriaService galeriaService, DataContext context)
        {
            _galeriaService = galeriaService;
            _context = context;
        }
        

          /*  private readonly DataContext _context;
        

         public GaleriaController(DataContext context)
        {  
            _context = context;
        }     */

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            
             try {
                // var galerias = await _galeriaService.GetAllGaleriasAsync();
                var galerias = _context.Galerias.ToArray();
                if(galerias == null) return NotFound("Nenhuma galeria encontrada");

               /*  var galeriasRetorno = new List<GaleriaDto>();

                foreach (var galeria in galerias) 
                {
                    galeriasRetorno.Add(new GaleriaDto()
                    {
                        Id = galeria.Id,
                        Concessao = galeria.Concessao,
                        Gallery = galeria.Gallery,
                        Descricao = galeria.Descricao,
                        DataAtualizacao = galeria.DataAtualizacao,
                        Elaborador = galeria.Elaborador,
                        QtdFotos = galeria.QtdFotos,
                        ImagemURL = galeria.ImagemURL
                  
                    });
                    }
                    
                 */
                

                return Ok(galerias);


                
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Banco de dados falhou GET. {ex.Message}");
            }

             /* return _context.Galerias;  */
             
        }
        

         [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try {
            //    var galeria = await _galeriaService.GetGaleriaByIdAsync(id);
                  var galeria =  _context.Galerias.Where(g => g.Id == id).First();
                if(galeria == null) return NoContent();

                return Ok(galeria);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Banco de dados falhou. {ex.Message}");
            }
            // return _context.Galerias.FirstOrDefault(galeria => galeria.Id == id); 
        }
        

        [HttpPost]
        public async Task<IActionResult> Post(GaleriaDto model)
        {
            try {
                var galeria = await _galeriaService.AddGaleria(model);
                if(galeria == null) return BadRequest("Galeria não cadastrada");

                return Ok(galeria);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar adicionar galeria. Erro {ex.Message}");
            }

            /* _context.Galerias.Add(galeria);
            _context.SaveChanges();
             
            return Ok(galeria); */
             
        }

        [HttpPut]
        public async Task<IActionResult> Put(Galeria model) /* So funciona com domain */
        {
            try {

                var galeria =  _context.Galerias.Where(g => g.Id == model.Id).First();

                if(galeria == null) 
                    return NotFound("Galeria não cadastrada / não existente");

                _context.Galerias.Update(model);
                _context.SaveChanges();
                

                return Ok(model);     /*duvida nesse (model) */
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $" Erro: {ex.Message}");
            }


            /* _context.Galerias.Update(galeria);
            _context.SaveChanges();
             
            return Ok(galeria); */
        }
        

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {

             try
              {
                return await _galeriaService.DeleteGaleria(id) ?
                 Ok("Galeria deletada") :
                BadRequest("Galeria não deletada");
                
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Banco de dados falhou. {ex.Message}");
            }


            /* var galeria = _context.Galerias.FirstOrDefault(galeria => galeria.Id == id);
            _context.Galerias.Remove(galeria);
            _context.SaveChanges();
            return Ok(galeria); */
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