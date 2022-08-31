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

         public async Task<Galeria> UpdateGaleria(int Id, Galeria model)
        {
            try {
                var galeria = await _galeriaPersistence.GetGaleriasByIdAsync(Id);
                if(galeria == null) return null;

                model.Id = galeria.Id;

                _geralPersistence.Update<Galeria>(model);
                if(await _geralPersistence.SaveChangesAsync()){
                    return await _galeriaPersistence.GetGaleriasByIdAsync(Id);
                }
                return null;
            }
            catch(Exception ex){
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteGaleria(int Id)
        {
             try {
                var galeria = await _galeriaPersistence.GetGaleriasByIdAsync(Id);
                if(galeria == null) throw new Exception("Galeria não encontrada");


                _geralPersistence.Delete<Galeria>(galeria);
                return await _geralPersistence.SaveChangesAsync();
                
            }
            catch(Exception ex){
                throw new Exception(ex.Message);
            }
        }

          public async Task<Galeria[]> GetAllGaleriaAsync(string Concessao)
        {
            try {
                var galerias = await _galeriaPersistence.GetAllGaleriasAsync(Concessao);
                if(galerias == null) return null;
                return galerias;
            }

            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
            public async Task<Galeria> GetGaleriasByIdAsync(int Id)
        {
            try {
                var galerias = await _galeriaPersistence.GetGaleriasByIdAsync(Id);
                if(galerias == null) return null;
                return galerias;
            }

            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


//Interface
        public Task<Galeria> UpdateGaleria(int Id)
        {
            throw new NotImplementedException();
        }

        Task<Galeria> IGaleriaService.DeleteGaleria(int Id)
        {
            throw new NotImplementedException();
        }
// End of interface

      

        

    }
}