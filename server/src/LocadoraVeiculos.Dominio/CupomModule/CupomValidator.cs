using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.Dominio.CupomModule
{
    internal class CupomValidator : AbstractValidator<Cupom>
    {
        public CupomValidator()
        {
            RuleFor(p => p.Nome).NotEmpty().NotNull().WithMessage("O campo {PropertyName} não pode ser vazio.");
            RuleFor(p => p.DataValidade).Equal(DateTime.MinValue).LessThan(DateTime.Now).WithMessage("A data Invalida, Insira uma data valida");
            RuleFor(p => p.ParceiroId).Equal(0).WithMessage("O campo {PropertyName} e não pode ser vazio.");
            RuleFor(p => p.ValorMinimo).Equal(0).LessThan(0).WithMessage("O campo {PropertyName} não pode ser vazio.");
            

        }
    }
}
