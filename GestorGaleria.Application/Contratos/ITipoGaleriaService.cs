using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using gestor.API;
using GestorGaleria.Application.Dtos;

namespace GestorGaleria.Application.Contratos
{
    public interface ITipoGaleriaService
    {
        Task<TiposDto[]> GetAllTiposByIdAsync(int Id);
        Task<TiposDto[]> GetAllTiposDeGaleriaAsync(string descricao);
        Task AddTipoGaleria(TiposDto model);

        Task<TiposDto> AddTipo(TiposDto model);

        Task<TiposDto> UpdateTipo(TiposDto model);

    
    }
}