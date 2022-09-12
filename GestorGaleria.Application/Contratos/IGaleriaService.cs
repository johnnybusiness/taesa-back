using System.Threading.Tasks;
using gestor.Application.Dtos;
using GestorGaleria.Domain;

namespace GestorGaleria.Application.Contratos
{
    public interface IGaleriaService
    {
        Task<GaleriaDto> AddGaleria(GaleriaDto model);

        Task<GaleriaDto> UpdateGaleria(int id, GaleriaDto model);

        Task<bool> DeleteGaleria(int id);

        Task<GaleriaDto[]> GetAllGaleriasAsync();

        Task<GaleriaDto> GetGaleriaByIdAsync(int Id);
        
        
    }
}