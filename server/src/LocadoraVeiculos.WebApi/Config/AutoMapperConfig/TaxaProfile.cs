using AutoMapper;
using LocadoraVeiculos.Dominio.TaxaModule;
using LocadoraVeiculos.WebApi.ViewModels;

namespace LocadoraVeiculos.WebApi.Config.AutoMapperConfig
{
    public class TaxaProfile : Profile
    {
        public TaxaProfile()
        {
            CreateMap<Taxa, TaxaListViewModel>();

            CreateMap<Taxa, TaxaDetailsViewModel>();
                       

            CreateMap<TaxaCreateViewModel, Taxa>()
                ;

            CreateMap<TaxaEditViewModel, Taxa>()
                ;
        }
    }
}
