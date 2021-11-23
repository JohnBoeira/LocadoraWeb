using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.Dominio.ClienteModule
{
    public class ClienteValidator : AbstractValidator<Cliente>
    {
   

        public ClienteValidator()
        {
            RuleFor(cliente => cliente.Nome).NotEmpty().NotNull().WithMessage("O nome é obrigatório e não pode ser vazio.");

            RuleFor(c => c.Endereco).NotNull().NotEmpty().WithMessage("O endereço é obrigatório e não pode ser vazio.");

            RuleFor(c => c.Telefone).MinimumLength(9).WithMessage("O Telefone está invalido.");

            RuleFor(c => c.CNPJ).Empty().When(c => c.CPF != null).WithMessage("O Campo {PropertyName} não pode ser salvo pois já há valor em CPF");

            RuleFor(c => c.CPF).Empty().When(c => c.CNPJ != null).WithMessage("O Campo {PropertyName} não pode ser salvo pois já há valor em CNPJ");

            RuleFor(c => c.CNPJ).NotEmpty().When(c => c.CPF == null).WithMessage("Preencha o campo CPF ou CNPJ");

            RuleFor(c => c.CPF).NotEmpty().When(c => c.CNPJ == null).WithMessage("Preencha o campo CPF ou CNPJ");

            RuleFor(c => c.RG).NotEmpty().NotNull().When(c => c.CPF != null).WithMessage("Campo {PropertyName} é obrigatório ");

            RuleFor(c => c.Email).EmailAddress().WithMessage("Email inválido");

            RuleFor(c => c.TipoPessoa).NotNull().NotEmpty().WithMessage("O Campo {PropertyName} é obrigatório");

        }
    }
}
