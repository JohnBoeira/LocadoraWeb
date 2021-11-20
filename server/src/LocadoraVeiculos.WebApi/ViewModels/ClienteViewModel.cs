using LocadoraVeiculos.Dominio;
using LocadoraVeiculos.Dominio.ClienteModule;
using LocadoraVeiculos.WebApi.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocadoraVeiculos.WebApi.ViewModels
{
    public class ClienteDetailsViewModel : EntityViewModelBase
    {
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }
        public string CNPJ { get; set; }
        public string RG { get; set; }
        public string CPF { get; set; }
        public int TipoPessoa { get; set; }
        public virtual string Email { get; set; }

    }

    public class ClienteCreateViewModel {
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }
        public string CNPJ { get; set; }
        public string RG { get ; set; }
        public virtual string CPF { get; set; }
        public int TipoPessoa { get; set; }
        public virtual string Email { get; set; }
    }

    public class ClienteListViewModel : EntityViewModelBase
    {
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public virtual string Email { get; set; }
    }

    public class ClienteEditViewModel : EntityViewModelBase
    {
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }
        public string CNPJ { get; set; }
        public string RG { get; set; }
        public virtual string CPF { get; set; }
        public int TipoPessoa { get; set; }
        public virtual string Email { get; set; }
    }

}
