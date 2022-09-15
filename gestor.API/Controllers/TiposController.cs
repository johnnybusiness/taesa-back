using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using gestor.Persistance;
using GestorGaleria.Application.Dtos;
using GestorGaleria.Application.Contratos;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace gestor.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TiposController : ControllerBase
    {
      
        private readonly DataContext _context;
        private readonly ITipoGaleriaService _tipoGaleriaService;

        private readonly IMapper _mapper;

        public TiposController(ITipoGaleriaService tipoGaleriaService, DataContext context, IMapper mapper)
        {
            _tipoGaleriaService = tipoGaleriaService;
            _context = context;
            _mapper = mapper;
        }
       

        [HttpGet]

        public async Task<IActionResult> Get()
        {
           try 
           {
            // var tipos = await _tipoGaleriaService.GetAllTiposDeGaleriaAsync("true");

            var tipos = await _context.Tipos.ToListAsync();
            if (tipos == null) return NotFound("Nenhum tipo de galeria encontrado");

            return Ok(tipos);

           /* var tipoRetorno = new List<TiposDto>();

             foreach (var tipo in tipos)
            {
                
                
                    tipoRetorno.Add(new TiposDto()
                {
                    Id = tipo.Id,
                    TiposDeGaleria  = tipo.TiposDeGaleria
                });
                
            } */

            // return Ok(tipos);
           }
              catch (Exception ex)
              {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Banco de dados falhou {ex.Message}");
              }
        }


        /* public IEnumerable<Tipos> Get()

        {
            
            return _context.Tipos;
        } */


        [HttpGet("{id}")]
        public IEnumerable<Tipos> GetById(int id)
        {
            return _context.Tipos.Where(tipos => tipos.Id == id);
        }

        [HttpPost]

        public async Task<IActionResult> Post(TiposDto model)
        {

            try {
                var tipo = await _tipoGaleriaService.AddTipo(model);
                if(tipo == null) return BadRequest("Tipo não cadastrada");

                return Ok(tipo);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar adicionar galeria. Erro {ex.Message}");
            }


           /*  try
            {
                var tipo = await _tipoGaleriaService.AddTipoGaleria(tipos);
                if (tipo == null) return BadRequest("Tipo de galeria não cadastrada");

                return Ok(tipos);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Banco de dados falhou {ex.Message}");
            } */


        }
       

       /*   public IActionResult Post(TiposDto tipos)
        {
            // return "value";
             _context.Tipos.Add(tipos);
            _context.SaveChanges();

            return Ok(tipos); 

        

        }  */
        

        /* [HttpPut("{id}")]
        public IActionResult Put(TiposDto tipos)
        {
            _context.Tipos.Update(tipos);
            _context.SaveChanges();

            return Ok(tipos);
        } */

        [HttpPut]
        public async Task<IActionResult> Put(TiposDto model)
        {
            try
            {
                var tipo = await _tipoGaleriaService.UpdateTipo(model);
                if (tipo == null) return BadRequest("Tipo não atualizada");

                return Ok(tipo);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar atualizar tipo. Erro {ex.Message}");
            }
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