using AutoMapper;
using LocadoraVeiculos.Aplicacao.TaxaModule;
using LocadoraVeiculos.Dominio.Shared;
using LocadoraVeiculos.Dominio.TaxaModule;
using LocadoraVeiculos.WebApi.Shared;
using LocadoraVeiculos.WebApi.ViewModels;

namespace LocadoraVeiculos.WebApi.Controllers
{
    public class TaxaController : ControladorBase<TaxaListViewModel, TaxaDetailsViewModel, TaxaCreateViewModel, TaxaEditViewModel, Taxa>
    {
        public TaxaController(ITaxaRepository taxaRepository, ITaxaAppService taxaAppService, IMapper mapper, INotificador notificador
            ) : base(taxaRepository, taxaAppService, mapper, notificador)
        {
        }
    }
}

