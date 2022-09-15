using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using gestor.API;
using GestorGaleria.Application.Contratos;
using GestorGaleria.Application.Dtos;
using GestorGaleria.Persistence.Contratos;
using gestor.Domain;
using AutoMapper;

namespace GestorGaleria.Application
{
    public class TipoGaleriaService : ITipoGaleriaService
    
    {
        private readonly IGeralPersistence _geralPersistence;
        private readonly ITipoGaleriaPersistence _tipoGaleriaPersistence;
         private readonly IMapper _mapper;

        public TipoGaleriaService(IGeralPersistence geralPersistence, 
        ITipoGaleriaPersistence tipoGaleriaPersistence,
        IMapper mapper)

        {
            _mapper = mapper;
            _geralPersistence = geralPersistence;
            _tipoGaleriaPersistence = tipoGaleriaPersistence;
        }

        public async Task<TiposDto> AddTipoGaleria(TiposDto model)
        {

             try
            {
                var tipo = _mapper.Map<Tipos>(model);

                _geralPersistence.Add<Tipos>(tipo);
                if (await _geralPersistence.SaveChangesAsync())
                {
            var tipoRetorno = await _tipoGaleriaPersistence.GetTipoGaleriaByIdAsync(tipo.Id, false);

                    return _mapper.Map<TiposDto>(tipoRetorno);
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            } 
        }

        public async Task<TiposDto> UpdateTipoGaleria(int tipoGaleriaId, TiposDto model)
        {

           try
            {
                var tipoGaleria = await _tipoGaleriaPersistence.GetTipoGaleriaByIdAsync(tipoGaleriaId, false);
                if (tipoGaleria == null) return null;

                model.Id = tipoGaleria.Id;

                _mapper.Map(model, tipoGaleria);

                _geralPersistence.Update<Tipos>(tipoGaleria);

                if (await _geralPersistence.SaveChangesAsync())
                {
                var tipoRetorno = await _tipoGaleriaPersistence.GetTipoGaleriaByIdAsync(tipoGaleria.Id, false);

            return _mapper.Map<TiposDto>(tipoRetorno);
                }
                return null;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            } 
        }

        public async Task <bool> DeleteTipoGaleria(int tipoGaleriaId)
        {
             try
            {
                var tipoGaleria = await _tipoGaleriaPersistence.GetTipoGaleriaByIdAsync(tipoGaleriaId, false);
                if (tipoGaleria == null) throw new Exception("Tipo de Galeria não encontrado");

              

                _geralPersistence.Delete<Tipos>(tipoGaleria);
                return await _geralPersistence.SaveChangesAsync();
         

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public async Task<TiposDto[]> GetAllTiposByIdAsync(int id)
        {
            try 
            {
                var tipoGaleria = await _tipoGaleriaPersistence.GetAllTiposByIdAsync(id);
                if (tipoGaleria == null) return null;

                var resultado = _mapper.Map<TiposDto[]>(tipoGaleria);

                return resultado;

            } 
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<TiposDto[]> GetAllTiposDeGaleriaAsync()
        {
            try 
            {
                var tiposGaleria = await _tipoGaleriaPersistence.GetAllTiposDeGaleriaAsync();
                if (tiposGaleria == null) return null;
            
                var resultado = _mapper.Map<TiposDto[]>(tiposGaleria);

                return resultado;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        Task<TiposDto[]> ITipoGaleriaService.GetAllTiposByIdAsync(int Id)
        {
            throw new NotImplementedException();
        }

        Task<TiposDto[]> ITipoGaleriaService.GetAllTiposDeGaleriaAsync(string descricao)
        {
            throw new NotImplementedException();
        }

        Task ITipoGaleriaService.AddTipoGaleria(TiposDto model)
        {
            throw new NotImplementedException();
        }

        Task<TiposDto> ITipoGaleriaService.AddTipo(TiposDto model)
        {
            throw new NotImplementedException();
        }

        Task<TiposDto> ITipoGaleriaService.UpdateTipo(TiposDto model)
        {
            throw new NotImplementedException();
        }
        
    }
}