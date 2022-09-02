using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestorGaleria.Domain;

namespace GestorGaleria.Application.Contratos
{
    public interface IGaleriaService
    {
        Task<Galeria> AddGaleria(Galeria model);

        Task<Galeria> UpdateGaleria(int id, Galeria model);

        Task<bool> DeleteGaleria(int id);

        Task<Galeria[]> GetAllGaleriasAsync();

        Task<Galeria> GetGaleriaByIdAsync(int Id);
        
        
    }
}