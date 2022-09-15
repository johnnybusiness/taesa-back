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
        Task GetGaleriaByIdAsync(int galeriaId, bool v);
        Task UpdateGaleria(int galeriaId, Galeria galeria);
        Task GetGaleriaByIdAsync(int galeriaId);
        Task GetGaleriasByIdAsync(int galeriaId);
    }
}