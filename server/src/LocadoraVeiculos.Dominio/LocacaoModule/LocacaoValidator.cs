using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.Dominio.LocacaoModule
{
    public class LocacaoValidator : AbstractValidator<Locacao>

    {
        public LocacaoValidator()
        {


            //if (RegistrandoDevolucao)
            //{
            //    if (QuilometragemPercorrida == 0)
            //        resultadoValidacao += QuebraDeLinha(resultadoValidacao) + "Informe a quilometragem percorrida";

            //    if (DataDevolucaoPrevista < DataLocacao)
            //        resultadoValidacao += QuebraDeLinha(resultadoValidacao) + "A data prevista da entrega não pode ser menor que data da locação";

            //    if (MarcadorCombustivel == MarcadorCombustivelEnum.NaoInformado)
            //        resultadoValidacao += QuebraDeLinha(resultadoValidacao) + "Informe o status do tanque de combustível";
            //}

            RuleFor(l => l.FuncionarioId).Equal(0).WithMessage("O campo {PropertyName} é obrigatório");
            RuleFor(l => l.VeiculoId).Equal(0).WithMessage("O campo {PropertyName} é obrigatório");
            RuleFor(l => l.CondutorId).Equal(0).WithMessage("O campo {PropertyName} é obrigatório");
            RuleFor(l => l.PlanoCobrancaId).Equal(0).WithMessage("O campo {PropertyName} é obrigatório");
            RuleFor(l => l.DataLocacao).Equal(DateTime.MinValue).WithMessage("O campo {PropertyName} é obrigatório");

            RuleFor(l => l.DataDevolucaoPrevista).Equal(DateTime.MinValue).WithMessage("O campo {PropertyName} é obrigatório");

            RuleFor(l => l.DataDevolucaoPrevista).LessThan(l => l.DataLocacao).WithMessage("O campo Data Devolução Prevista está inválido");

            

            RuleFor(l => l.VeiculoId).NotEqual(0).When(l => l.Veiculo.EstaAlugado() == true).WithMessage("Veículo já alugado");
            //devolução
            RuleFor(l => l.QuilometragemPercorrida).NotEqual(0).When(l => l.RegistrandoDevolucao == true).WithMessage("O campo {PropertyName} é obrigatório");
            RuleFor(l => l.DataDevolucaoRealizada).LessThan(l => l.DataLocacao).When(l => l.RegistrandoDevolucao == true).WithMessage("O campo {PropertyName} é obrigatório");
            RuleFor(l => l.MarcadorCombustivel).NotEqual(MarcadorCombustivelEnum.NaoInformado).When(l => l.RegistrandoDevolucao == true).WithMessage("O campo {PropertyName} é obrigatório");

            

        }
    }
}
