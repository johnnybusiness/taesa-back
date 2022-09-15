using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using gestor.API;
using gestor.Domain;
using GestorGaleria.Domain;

namespace GestorGaleria.Persistence.Contratos
{
    public interface ITipoGaleriaPersistence
    {
        // TipoGaleria

        Task<Tipos[]> GetAllTiposByIdAsync(int id);
        Task<Tipos[]> GetAllTiposDeGaleriaAsync();
        /*  Task GetTipoGaleriaByIdAsync(int tipoGaleriaId);  */

        Task<bool> DeleteTipoGaleria(int tipoGaleriaId);
        Task GetTipoGaleriaByIdAsync(int tipoGaleriaId);
        Task<Tipos> GetTipoGaleriaByIdAsync(object id);
        Task<Tipos> GetTipoGaleriaByIdAsync(int id, bool v);
    }
}