using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestorGaleria.Application.Contratos;
using GestorGaleria.Domain;
using GestorGaleria.Persistence.Contratos;

namespace GestorGaleria.Application
{
    public class GaleriaService : IGaleriaService
    {

        private readonly IGeralPersistence _geralPersistence;
        private readonly IGestorGaleriaPersistence _galeriaPersistence;
        public GaleriaService(IGeralPersistence geralPersistence, IGestorGaleriaPersistence galeriaPersistence)
        {
            _geralPersistence = geralPersistence;
            _galeriaPersistence = galeriaPersistence;
        }

        public async Task<Galeria> AddGaleria(Galeria model)
        {
            try{
                _geralPersistence.Add<Galeria>(model);
                if(await _geralPersistence.SaveChangesAsync()){
                    return await _galeriaPersistence.GetGaleriasByIdAsync(model.Id);
                }
                return null;
            }
            catch(Exception ex){
                throw new Exception(ex.Message);
            }
        }

         public async Task<Galeria> UpdateGaleria(int id, Galeria model)
        {
            try {
                var galeria = await _galeriaPersistence.GetGaleriasByIdAsync(id);
                if(galeria == null) return null;

                model.Id = galeria.Id;

                _geralPersistence.Update<Galeria>(model);
                if(await _geralPersistence.SaveChangesAsync()){
                    return await _galeriaPersistence.GetGaleriasByIdAsync(id);
                }
                return null;
            }
            catch(Exception ex){
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteGaleria(int id)
        {
             try {
                var galeria = await _galeriaPersistence.GetGaleriasByIdAsync(id);
                if(galeria == null) throw new Exception("Galeria não encontrada");


                _geralPersistence.Delete<Galeria>(galeria);
                return await _geralPersistence.SaveChangesAsync();
                
            }
            catch(Exception ex){
                throw new Exception(ex.Message);
            }
        }

          // public async Task<Galeria[]> GetAllGaleriaAsync(string Concessao)
          public async Task<Galeria[]> GetAllGaleriaAsync()
        {
            try {
                var galerias = await _galeriaPersistence.GetAllGaleriasAsync();
                if(galerias == null) return null;
                return galerias;
            }

            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
            public async Task<Galeria> GetGaleriasByIdAsync(int id)
        {
            try {
                var galerias = await _galeriaPersistence.GetGaleriasByIdAsync(id);
                if(galerias == null) return null;
                return galerias;
            }

            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


//Interface
        public Task<Galeria> UpdateGaleria(int id)
        {
            throw new NotImplementedException();
        }

       

        public Task<Galeria[]> GetAllGaleriasAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Galeria> GetGaleriaByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
        // End of interface





    }
}