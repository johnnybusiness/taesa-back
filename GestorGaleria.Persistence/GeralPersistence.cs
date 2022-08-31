using System;
using System.Threading.Tasks;
using gestor.Domain;
using gestor.Persistance;
using GestorGaleria.Domain;
using GestorGaleria.Persistence.Contratos;

namespace GestorGaleria.Persistence
{
    public class GeralPersistence : IGeralPersistence
    {
        private readonly DataContext _context;
        public GeralPersistence(DataContext context)
        {
            _context = context;
        }
       
       
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }
        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public void DeleteRange<T>(T[] entityArray) where T : class
        {
            _context.RemoveRange(entityArray);
        }
         public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }
        
        // Galeria
        // public async Task<Galeria[]> GetAllGaleriasAsync(int Id, string Gallery, string concessao,
        //  string elaborador, string descricao, DateTime dataAtualizacao, int qtdFotos)
        /* public async Task<Galeria[]> GetAllGaleriasAsync()
        {
            return await _context.Galerias.ToArrayAsync();

            // IQueryable<Galeria> query = _context.Galerias
            // .Include(g => g.Id)
            // .Include(g => g.Concessao)
            // .Include(g => g.Gallery)
            // .Include(g => g.Descricao)
            // .Include(g => g.DataAtualizacao)
            // .Include(g => g.Elaborador)
            // .Include(g => g.QtdFotos)
            // .Include(g => g.ImagemURL);

            //  query = query.OrderBy(d => d.Id);
            //  return await query.ToArrayAsync();
          
        }

       


        public async Task<Galeria> GetGaleriasByIdAsync(int Id)
        {
            IQueryable<Galeria> query = _context.Galerias
            .Include(g => g.Id);
            

             query = query.OrderBy(g => g.Id).Where(g => g.Id == Id);
             return await query.FirstOrDefaultAsync();

        }



        // Concessões


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
       
        
        // Tipo de Galeria
        public Task<Tipos[]> GetAllTiposByIdAsync(int Id)
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
        }
 */


        // Interfaces IGestorGaleriaPersistence

        public Task<Galeria> GetGaleriasByIdAsync(string gallery)
        {
            throw new NotImplementedException();
        }

        public Task<Concessoes[]> GetAllConcessoesAsync(string Nome, bool includeGalerias)
        {
            throw new NotImplementedException();
        }

        public Task<Concessoes[]> GetAllConcessoesByIdAsync(int Id, bool includeGalerias)
        {
            throw new NotImplementedException();
        }

        public Task<Galeria[]> GetAllGaleriasAsync(string concessao)
        {
            throw new NotImplementedException();
        }
    }
}