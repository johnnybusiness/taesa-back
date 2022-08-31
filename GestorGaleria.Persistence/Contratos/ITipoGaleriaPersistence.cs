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

        Task<Tipos[]> GetAllTiposByIdAsync(int Id);
        Task<Tipos[]> GetAllTiposDeGaleriaAsync(string descricao);
        
    }
}