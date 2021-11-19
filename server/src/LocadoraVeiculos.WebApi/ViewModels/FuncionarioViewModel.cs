using LocadoraVeiculos.WebApi.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocadoraVeiculos.WebApi.ViewModels
{
    public class FuncionarioListViewModel : EntityViewModelBase
    {
        public string Nome { get; set; }

        public string Usuario { get; set; }
    }

    public class FuncionarioDetailsViewModel : EntityViewModelBase
    {
        public string Nome { get; set; }

        public string Usuario { get; set; }

        public string Senha { get; set; }

        public decimal Salario { get; set; }

        public DateTime DataAdmissao { get; set; }

    }

    public class FuncionarioCreateViewModel
    {
        public string Nome { get; set; }

        public string Usuario { get; set; }

        public string Senha { get; set; }

        public decimal Salario { get; set; }

        public DateTime DataAdmissao { get; set; }
    }

    public class FuncionarioEditViewModel : EntityViewModelBase
    {
        public string Nome { get; set; }

        public string Usuario { get; set; }

        public string Senha { get; set; }

        public decimal Salario { get; set; }

        public DateTime DataAdmissao { get; set; }
    }
}
