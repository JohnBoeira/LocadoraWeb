using AutoMapper;
using LocadoraVeiculos.Dominio.ClienteModule;
using LocadoraVeiculos.WebApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocadoraVeiculos.WebApi.Config.AutoMapperConfig
{
    public class CondutorProfile : Profile
    {
        public CondutorProfile()
        {
            CreateMap<Condutor, CondutorListViewModel>()
                 ;

            CreateMap<Condutor, CondutorDetailsViewModel>()
                ;

            CreateMap<CondutorCreateViewModel, Condutor>()
           
                ;

            CreateMap<CondutorEditViewModel, Condutor>()
                ;
        }
    }
}
