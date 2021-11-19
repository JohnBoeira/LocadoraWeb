using LocadoraVeiculos.WebApi.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocadoraVeiculos.WebApi.ViewModels
{
    public class ParceiroListViewModel : EntityViewModel
    {


        public string Nome { get; set; }
    }

    public class ParceiroDetailsViewModel : EntityViewModel
    {
     

        public string Nome { get; set; }

        public List<CupomListViewModel> Cupons { get; set; }
    }

    public class ParceiroCreateViewModel
    {
        public string Nome { get; set; }
    }

    public class ParceiroEditViewModel : EntityViewModel
    {

        public string Nome { get; set; }
    }
}
