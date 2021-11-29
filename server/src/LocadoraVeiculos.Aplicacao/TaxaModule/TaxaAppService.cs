using LocadoraVeiculos.Aplicacao.Shared;
using LocadoraVeiculos.Dominio.TaxaModule;
using System.Collections.Generic;

namespace LocadoraVeiculos.Aplicacao.TaxaModule
{
    public interface ITaxaAppService : IAppService<Taxa>
    {

        List<Taxa> SelecionarTaxasNaoAdicionadas(List<Taxa> taxasJaAdicionadas);
    }
    public class TaxaAppService : ITaxaAppService
    {
        private readonly ITaxaRepository taxaRepository;

        public TaxaAppService(ITaxaRepository taxaRepository)
        {
            this.taxaRepository = taxaRepository;
        }

        public List<Taxa> SelecionarTaxasNaoAdicionadas(List<Taxa> taxasJaAdicionadas)
        {
            return taxaRepository.SelecionarTaxasNaoAdicionadas(taxasJaAdicionadas);
        }

        public List<Taxa> SelecionarTodos()
        {
            return taxaRepository.SelecionarTodos();
        }
    }
}
