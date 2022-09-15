using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using gestor.API;
using GestorGaleria.Application.Dtos;

namespace GestorGaleria.Application.Helpers
{
    public class TiposProfile : Profile
    {
        public TiposProfile() 
        {
            CreateMap<Tipos, TiposDto>();
            CreateMap<TiposDto, Tipos>();
            
        }
    }
}