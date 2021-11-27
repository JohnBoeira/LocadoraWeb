using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.Dominio.ClienteModule
{
    public class CondutorValidator : AbstractValidator<Condutor>
    {
        public CondutorValidator()
        {
            RuleFor(cliente => cliente.Nome).NotEmpty().NotNull().WithMessage("O nome é obrigatório e não pode ser vazio.");

            RuleFor(c => c.Endereco).NotNull().NotEmpty().WithMessage("O endereço é obrigatório e não pode ser vazio.");

            RuleFor(c => c.Telefone).MinimumLength(9).WithMessage("O Telefone está invalido.");

            RuleFor(c => c.Cpf).NotEmpty().NotNull().WithMessage("Campo {PropertyName} é obrigatório");

            RuleFor(c => c.Cnh).NotEmpty().NotNull().WithMessage("Campo {PropertyName} é obrigatório");

            RuleFor(c => c.Rg).NotEmpty().NotNull().WithMessage("Campo {PropertyName} é obrigatório ");

            RuleFor(c => c.DataValidadeCnh).NotEqual(DateTime.MinValue).WithMessage("Campo {PropertyName} é obrigatório ");

            RuleFor(c => c.DataValidadeCnh).NotNull().NotEmpty().WithMessage("A validade da cnh inserida está expirada, tente novamente");

            RuleFor(c => c.ClienteId).NotEqual(0).WithMessage("O campo Cliente é obrigatório e não pode ser Vazio");

     
        }
    }
}
