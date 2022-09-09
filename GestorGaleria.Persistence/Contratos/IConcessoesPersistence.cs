using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using gestor.API;
using gestor.Domain;
using GestorGaleria.Domain;

namespace GestorGaleria.Persistence.Contratos
{
    public interface IConcessoesPersistence
    {

        // Concessões
        Task<Concessoes[]> GetAllConcessoesAsync(string Nome);
        Task<Concessoes> GetConcessoesByIdAsync(int id);
        Task GetAllConcessoesAsync();
    }
}