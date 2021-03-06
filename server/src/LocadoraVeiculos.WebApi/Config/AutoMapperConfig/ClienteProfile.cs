using AutoMapper;
using LocadoraVeiculos.Dominio;
using LocadoraVeiculos.Dominio.ClienteModule;
using LocadoraVeiculos.Dominio.CupomModule;
using LocadoraVeiculos.WebApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocadoraVeiculos.WebApi.Config.AutoMapperConfig
{
    public class ClienteProfile : Profile
    {

        public ClienteProfile()
        {

            CreateMap<Cliente, ClienteListViewModel>();

            CreateMap<Cliente, ClienteDetailsViewModel>()
                        .ForMember(dest => dest.TipoPessoa, opt => opt.MapFrom(src => (int)src.TipoPessoa));

            CreateMap<ClienteCreateViewModel, Cliente>()
                .ForMember(dest => dest.TipoPessoa, opt => opt.MapFrom(src => (TipoPessoaEnum)src.TipoPessoa));

            CreateMap<ClienteEditViewModel, Cliente>()
                .ForMember(dest => dest.TipoPessoa, opt => opt.MapFrom(src => (TipoPessoaEnum)src.TipoPessoa));
        }
    }
}
