using System;
using System.Linq;
using System.Threading.Tasks;
using gestor.API;
using gestor.Domain;
using gestor.Persistance;
/* using gestor.Persistance.Contextos;
 */
 using GestorGaleria.Domain;
using GestorGaleria.Persistence.Contratos;
using Microsoft.EntityFrameworkCore;

namespace GestorGaleria.Persistence
{
    public class GestorGaleriaPersistence : IGestorGaleriaPersistence
    {
        private readonly DataContext _context;
        public GestorGaleriaPersistence(DataContext context)
        {
            _context = context;
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }
       

        
        // Galeria
       
        public async Task<Galeria[]> GetAllGaleriasAsync()
        {
            
             return await _context.Galerias.ToArrayAsync();
  
          /*
              IQueryable<Galeria> query = _context.Galerias
             .Include(g => g.Id)
             .Include(g => g.Concessao)
             .Include(g => g.Gallery)
             .Include(g => g.Descricao)
             .Include(g => g.DataAtualizacao)
             .Include(g => g.Elaborador)
             .Include(g => g.QtdFotos)
             .Include(g => g.ImagemURL);

            query = query.AsNoTracking()
                         .OrderBy(g => g.Id); 

            return await query.ToArrayAsync();
             /* query = query.AsNoTracking().OrderBy(d => d.Id);
              return await query.ToArrayAsync(); */

        }

         public async Task<Galeria> GetGaleriasByIdAsync(int id)
        {

                /* IQueryable<Galeria> query = _context.Galerias.Include(g => g.Id);
            

             query = query.AsNoTracking().OrderBy(g => g.Id).Where(g => g.Id == id);
             
              return await query.FirstOrDefaultAsync();   */

              

              return await _context.Galerias.FirstOrDefaultAsync(g => g.Id == id);

              
          }

        



        // Concessões
        /* 

                public async Task<Concessoes[]> GetAllConcessoesByIdAsync(int Id)
                {
                    IQueryable<Concessoes> query = _context.Concessoes
                    .Include(c => c.Id);

                    query = query.OrderBy(c => c.Id).Where(c => c.Id == Id);
                    return await query.ToArrayAsync();
                }


                public async Task<Concessoes[]> GetAllConcessoesByNomeAsync(string Nome)

                {
                    IQueryable<Concessoes> query = _context.Concessoes
                    .Include(n => n.Nome);

                    query = query.OrderBy(n => n.Nome).Where(n => n.Nome == Nome);
                    return await query.ToArrayAsync();
                }
                */

        // Tipo de Galeria
        /*  public Task<Tipos[]> GetAllTiposByIdAsync(int Id)
         {
             IQueryable<Tipos> query = _context.Tipos
             .Include(t => t.Id);
             query = query.OrderBy(t => t.Id).Where(t => t.Id == Id);
             return query.ToArrayAsync();
         }

         public Task<Tipos[]> GetAllTiposDeGaleriaAsync(string TiposDeGaleria)
         {
             IQueryable<Tipos> query = _context.Tipos
             .Include(t => t.TiposDeGaleria);
             query = query.OrderBy(t => t.TiposDeGaleria).Where(t => t.TiposDeGaleria == TiposDeGaleria);
             return query.ToArrayAsync();
         } */



        // Interfaces IGestorGaleriaPersistence




        /* public Task<Concessoes[]> GetAllConcessoesByIdAsync(int Id, bool includeGalerias)
        {
            throw new NotImplementedException();
        } */

        /*   public Task<Galeria[]> GetAllGaleriasAsync(string concessao)
          {
              throw new NotImplementedException();
          } */

        /* public Task<Galeria[]> GetAllGaleriasByDescricaoAsync(string descricao)
        {
            throw new NotImplementedException();
        } */

        /* public Task<Concessoes[]> GetAllConcessoesAsync(int Id)
        {
            throw new NotImplementedException();
        } */

        /* public Task<Concessoes[]> GetAllConcessoesAsync(string ConcessaoID)
        {
            throw new NotImplementedException();
        } */

        /* public Task<Galeria> GetGaleriaByIdAsync(int id)
        {
            throw new NotImplementedException();
        } */
    }
}