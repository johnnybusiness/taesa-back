using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using gestor.API;
using gestor.Domain;
using GestorGaleria.Domain;

namespace GestorGaleria.Persistence.Contratos
{
    public interface IGestorGaleriaPersistence
    {
    // GERAL

 /// Add, Update, Delete, DeleteRange are generic functions that take in a class and return void

   /*  void Add <T> (T entity) where T: class;
    void Update <T> (T entity) where T: class;

    void Delete <T> (T entity) where T: class;

    void DeleteRange <T> (T[] entity) where T: class;

        Task<bool> SaveChangesAsync(); */

        // Galeria
                    // !IMPORTANTE!
        Task<Galeria[]> GetAllGaleriasAsync(string concessao);
        Task<Galeria> GetGaleriasByIdAsync(int id);
    }
}