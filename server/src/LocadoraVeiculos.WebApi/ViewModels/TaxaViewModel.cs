using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocadoraVeiculos.WebApi.ViewModels
{
    public class TaxaListViewModel
    {
    }
    public class TaxaCreateViewModel
    {
        public string Nome { get; set; }
        public decimal Valor { get; }
        public int TipoTaxa { get; }
    }
    public class TaxaEditViewModel
    {
    }
    public class TaxaDetailsViewModel
    {
    }
}
