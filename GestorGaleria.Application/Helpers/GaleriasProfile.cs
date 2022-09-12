using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using gestor.Application.Dtos;
using GestorGaleria.Domain;

namespace gestor.API.Helpers
{
    public class GaleriasProfile : Profile
    {
        public GaleriasProfile()
        {
            CreateMap<Galeria, GaleriaDto>();
           
        }
    }
}