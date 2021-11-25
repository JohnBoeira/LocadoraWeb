using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.Dominio.TaxaModule
{
    public class TaxaValidator : AbstractValidator<Taxa>
    {

        public TaxaValidator()
        {
            RuleFor(l => l.Nome).NotEmpty().NotNull().WithMessage("O campo {PropertyName} é obrigatório");
            RuleFor(l => l.Valor).LessThanOrEqualTo(0).WithMessage("O campo {PropertyName} é obrigatório");
            RuleFor(l => ((int)l.TipoTaxa)).LessThan(0).WithMessage("O campo {PropertyName} é obrigatório");
        }
    }
}
