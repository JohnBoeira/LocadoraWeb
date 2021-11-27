using LocadoraVeiculos.WebApi.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocadoraVeiculos.WebApi.ViewModels
{  
    public class TaxaCreateViewModel
    {
        public string Nome { get; set; }
        public decimal Valor { get; set; }
        public int TipoTaxa { get; set; }
    }
    public class TaxaEditViewModel : EntityViewModelBase
    {
        public string Nome { get; set; }
        public decimal Valor { get; set; }
        public int TipoTaxa { get; set; }
    }
    public class TaxaDetailsViewModel : EntityViewModelBase
    {
        public string Nome { get; set; }
        public decimal Valor { get; set; }
        public int TipoTaxa { get; set; }
    }
    public class TaxaListViewModel : EntityViewModelBase
    {
        public string Nome { get; set; }
        public decimal Valor { get; set; }
        public int TipoTaxa { get; set; }
    }
}
