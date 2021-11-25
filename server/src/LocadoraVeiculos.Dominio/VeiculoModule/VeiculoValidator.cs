using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.Dominio.VeiculoModule
{
    public  class VeiculoValidator : AbstractValidator<Veiculo>
    {
        public VeiculoValidator()
        {

            RuleFor(v => v.Placa).NotEmpty().NotNull().WithMessage("O campo {PropertyName} é obrigatório");
            RuleFor(v => v.Modelo).NotEmpty().NotNull().WithMessage("O campo {PropertyName} é obrigatório");
            RuleFor(v => v.Fabricante).NotEmpty().NotNull().WithMessage("O campo {PropertyName} é obrigatório");
            RuleFor(v => v.Quilometragem).LessThan(0).WithMessage("O campo {PropertyName} está inválido");
            RuleFor(v => v.QtdLitrosTanque).LessThanOrEqualTo(0).WithMessage("O campo {PropertyName} está inválido");
            RuleFor(v => ((int)v.TipoCombustivel)).LessThan(1).GreaterThan(3).WithMessage("O campo {PropertyName} está inválido");


        }
    }
}
