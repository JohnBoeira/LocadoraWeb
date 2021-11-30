using FluentValidation;
using LocadoraVeiculos.Aplicacao.Shared;
using LocadoraVeiculos.Dominio;
using LocadoraVeiculos.Dominio.Shared;
using LocadoraVeiculos.Dominio.TaxaModule;
using System.Collections.Generic;

namespace LocadoraVeiculos.Aplicacao.TaxaModule
{
    public interface ITaxaAppService : IAppService<Taxa>
    {

        List<Taxa> SelecionarTaxasNaoAdicionadas(List<Taxa> taxasJaAdicionadas);
    }
    public class TaxaAppService : AppServiceBase
    {
        private readonly ITaxaRepository taxaRepository;

        public TaxaAppService(ITaxaRepository taxaRepository, INotificador notificador) : base((IRepository<EntidadeBase<int>, int>)taxaRepository, notificador)
        {
            this.taxaRepository = taxaRepository;
        }

        public List<Taxa> SelecionarTaxasNaoAdicionadas(List<Taxa> taxasJaAdicionadas)
        {
            return taxaRepository.SelecionarTaxasNaoAdicionadas(taxasJaAdicionadas);
        }

        
    }
}
