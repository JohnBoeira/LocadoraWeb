using LocadoraVeiculos.WebApi.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocadoraVeiculos.WebApi.ViewModels
{
    public class CondutorListViewModel : EntityViewModelBase
    {
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }
        public string ClienteNome { get; set; }
    }

    public class CondutorCreateViewModel
    {
        public string Nome { get;  set; }
        public string Endereco { get;  set; }
        public string Telefone { get;  set; }
        public string Rg { get;set; }
        public string Cpf { get; set; }
        public string Cnh { get; set; }
        public DateTime DataValidadeCnh { get;  set; }
        public int ClienteId { get;  set; }
    }

    public class CondutorEditViewModel
    {
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }
        public string Rg { get; set; }
        public string Cpf { get; set; }
        public string Cnh { get; set; }
        public DateTime DataValidadeCnh { get; set; }
        public int ClienteId { get; set; }
    }

    public class CondutorDetailsViewModel
    {
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }
        public string Rg { get; set; }
        public string Cpf { get; set; }
        public string Cnh { get; set; }
        public DateTime DataValidadeCnh { get; set; }
        public int ClienteId { get; set; }
    }
}
