using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.Dominio.FuncionarioModule
{
    public class FuncionarioValidator : AbstractValidator<Funcionario>
    {

        public FuncionarioValidator()
        {
            RuleFor(f => f.Nome).NotEmpty().NotNull().WithMessage("O campo {PropertyName} é obrigatório");
            RuleFor(f => f.Senha).NotEmpty().NotNull().WithMessage("O campo {PropertyName} é obrigatório");
            RuleFor(f => f.Usuario).NotEmpty().NotNull().WithMessage("O campo {PropertyName} é obrigatório");
            RuleFor(f => f.Salario).NotEmpty().NotNull().WithMessage("O campo {PropertyName} é obrigatório");
            RuleFor(f => f.DataAdmissao).Equal(DateTime.MinValue).WithMessage("O campo {PropertyName} é obrigatório");
            RuleFor(f => f.DataAdmissao).LessThan(DateTime.Now).WithMessage("O campo {PropertyName} está inválido");
        }
    }
}
