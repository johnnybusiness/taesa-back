using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using gestor.Application.Dtos;
using GestorGaleria.Application.Contratos;
using GestorGaleria.Domain;
using GestorGaleria.Persistence.Contratos;

namespace GestorGaleria.Application
{
    public class GaleriaService : IGaleriaService
    {

        private readonly IGeralPersistence _geralPersistence;
        private readonly IGestorGaleriaPersistence _galeriaPersistence;
        private readonly IMapper _mapper;

        public GaleriaService(IGeralPersistence geralPersistence, 
                              IGestorGaleriaPersistence galeriaPersistence,
                             IMapper mapper)

       
        {
            _geralPersistence = geralPersistence;
            _galeriaPersistence = galeriaPersistence;
            _mapper = mapper;
        }

        public async Task<GaleriaDto> AddGaleria(GaleriaDto model)
        {

            /*  return null; */

             try
             {
                var galeria = _mapper.Map<Galeria>(model);

                _geralPersistence.Add<Galeria>(galeria);
                if(await _geralPersistence.SaveChangesAsync())
                {
                    var retorno = await _galeriaPersistence.GetGaleriasByIdAsync(galeria.Id);
                    
                    return _mapper.Map<GaleriaDto>(retorno);
                }
                return null;
            }
            catch(Exception ex){
                throw new Exception(ex.Message);
            } 
        }

         public async Task<GaleriaDto> UpdateGaleria(int id, GaleriaDto model)
        {

            try {
                var galeria = await _galeriaPersistence.GetGaleriasByIdAsync(id);
                if(galeria == null) return null;

                model.Id = galeria.Id;

                _mapper.Map(model, galeria);

                _geralPersistence.Update(galeria);

                if(await _geralPersistence.SaveChangesAsync())
                {
                    var retorno = await _galeriaPersistence.GetGaleriasByIdAsync(galeria.Id);
                    return _mapper.Map<GaleriaDto>(retorno);
                }
                return null;
            }
            catch (Exception ex){
                throw new Exception(ex.Message);
            }

        }


            /* return null; */


             /* try {
                var galeria = await _galeriaPersistence.GetGaleriasByIdAsync(id);
                if(galeria == null) return null;

                model.Id = galeria.Id;

                _geralPersistence.Update<GaleriaDto>(model);
                if(await _geralPersistence.SaveChangesAsync()){
                    return await _galeriaPersistence.GetGaleriasByIdAsync(id);
                }
                return null;
            }
            catch(Exception ex){
                throw new Exception(ex.Message);
            }  */
        

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
          public async Task<GaleriaDto[]> GetAllGaleriaAsync()
        {
            try {
                var galerias = await _galeriaPersistence.GetAllGaleriasAsync();
                if(galerias == null) return null;

                

               var resultado = _mapper.Map<GaleriaDto[]>(galerias);
                
                return resultado; 
            }

            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /*############ GetGaleriasByIdAsync #############*/
            public async Task<GaleriaDto> GetGaleriasByIdAsync(int id)
        {
            try {
                var galeria = await _galeriaPersistence.GetGaleriasByIdAsync(id);
                if(galeria == null) return null;

                var resultado = _mapper.Map<GaleriaDto>(galeria);
                
                return resultado;
            }

            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<GaleriaDto> GetGaleriaByIdAsync(int id)
        {
            try {
                var galeria = await _galeriaPersistence.GetGaleriasByIdAsync(id);
                if(galeria == null) return null;

                var resultado = _mapper.Map<GaleriaDto>(galeria);
                
                return resultado;
            }

            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }




//Interface
        public Task<GaleriaDto> UpdateGaleria(int id)
        {
            throw new NotImplementedException();
        }

       

        public Task<Galeria[]> GetAllGaleriasAsync()
        {
            throw new NotImplementedException();
        }


        Task<GaleriaDto[]> IGaleriaService.GetAllGaleriasAsync()
        {
            throw new NotImplementedException();
        }

        public Task GetGaleriaByIdAsync(int galeriaId, bool v)
        {
            throw new NotImplementedException();
        }

        public Task UpdateGaleria(int galeriaId, Galeria galeria)
        {
            throw new NotImplementedException();
        }

        Task IGaleriaService.GetGaleriaByIdAsync(int galeriaId)
        {
            throw new NotImplementedException();
        }

        Task IGaleriaService.GetGaleriasByIdAsync(int galeriaId)
        {
            throw new NotImplementedException();
        }
        // End of interface


    }
}