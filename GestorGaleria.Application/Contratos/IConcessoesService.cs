using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using gestor.Domain;

namespace GestorGaleria.Application.Contratos
{
    public interface IConcessoesService
    {
        Task<Concessoes> AddConcessao(Concessoes model);

        Task<Concessoes> UpdateConcessao(int concessaoId, Concessoes model);

        Task<bool> DeleteConcessao(int concessaoId);

        Task<Concessoes[]> GetAllConcessoesAsync();

        Task<Concessoes[]> GetAllConcessoesByNomeAsync(string nome);

        Task<Concessoes> GetConcessoesByIdAsync(int id);
    }
}