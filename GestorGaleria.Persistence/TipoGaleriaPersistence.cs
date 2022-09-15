using System;
using System.Linq;
using System.Threading.Tasks;
using gestor.API;
using gestor.Domain;
using gestor.Persistance;
using GestorGaleria.Domain;
using GestorGaleria.Persistence.Contratos;
using Microsoft.EntityFrameworkCore;

namespace GestorGaleria.Persistence
{
    public class TipoGaleriaPersistence : ITipoGaleriaPersistence
    {
        private readonly DataContext _context;
        public TipoGaleriaPersistence(DataContext context)
        {
            _context = context;
        }
        
        // Tipo de Galeria
        public Task<Tipos[]> GetAllTiposByIdAsync(int id)
        {
            IQueryable<Tipos> query = _context.Tipos
            .Include(t => t.Id);
            query = query.OrderBy(t => t.Id).Where(t => t.Id == id);
            return query.ToArrayAsync();
        }

        public Task<Tipos[]> GetAllTiposDeGaleriaAsync(string TiposDeGaleria)
        {
            IQueryable<Tipos> query = _context.Tipos
            .Include(t => t.TiposDeGaleria);
            query = query.OrderBy(t => t.TiposDeGaleria).Where(t => t.TiposDeGaleria == TiposDeGaleria);
            return query.ToArrayAsync();
        }



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

        public Task<Tipos> GetTipoGaleriaByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteTipoGaleria(int tipoGaleriaId)
        {
            throw new NotImplementedException();
        }

        Task ITipoGaleriaPersistence.GetTipoGaleriaByIdAsync(int tipoGaleriaId)
        {
            throw new NotImplementedException();
        }
        
        Task<Tipos> ITipoGaleriaPersistence.GetTipoGaleriaByIdAsync(object id)
        {
            throw new NotImplementedException();
        }
        
        Task<Tipos> ITipoGaleriaPersistence.GetTipoGaleriaByIdAsync(int id, bool v)
        {
            throw new NotImplementedException();
        }

        public Task<Tipos[]> GetAllTiposDeGaleriaAsync()
        {
            throw new NotImplementedException();
        }
    }
}