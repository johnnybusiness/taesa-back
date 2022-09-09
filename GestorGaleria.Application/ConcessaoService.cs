/* using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using gestor.Domain;
using GestorGaleria.Persistence.Contratos;

namespace GestorGaleria.Application
{
    public class ConcessaoService
    {
        private readonly IGeralPersistence _geralPersistence;
        private readonly IConcessoesPersistence _concessoesPersistence;
        public ConcessaoService(IGeralPersistence geralPersistence, IConcessoesPersistence concessoesPersistence)
        {
            _geralPersistence = geralPersistence;
            _concessoesPersistence = concessoesPersistence;
        }

        public async Task<Concessoes> AddConcessao(Concessoes model)
        {
            try
            {
                _geralPersistence.Add<Concessoes>(model);

                if (await _geralPersistence.SaveChangesAsync())
                {
                    return await _concessoesPersistence.GetConcessoesByIdAsync(model.Id);
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Concessoes> UpdateConcessao(int id, Concessoes model)
        {
            try
            {
                var concessao = await _concessoesPersistence.GetConcessoesByIdAsync(id);
                if (concessao == null) return null;

                model.Id = concessao.Id;

                _geralPersistence.Update<Concessoes>(model);
                if (await _geralPersistence.SaveChangesAsync())
                {
                    return await _concessoesPersistence.GetConcessoesByIdAsync(id);
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteConcessao(int id)
        {
            try
            {
                var concessao = await _concessoesPersistence.GetConcessoesByIdAsync(id);
                if (concessao == null) throw new Exception("Concessão não encontrada");

                _geralPersistence.Delete<Concessoes>(concessao);
                return await _geralPersistence.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }



        public async Task<Concessoes[]> GetAllConcessoesAsync()
        {
            try
            {
                var concessoes = await _concessoesPersistence.GetAllConcessoesAsync();
                if (concessoes == null) return null;

                return concessoes;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
} */