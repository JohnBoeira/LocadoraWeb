using LocadoraVeiculos.Aplicacao.Shared;
using LocadoraVeiculos.Dominio.FuncionarioModule;
using LocadoraVeiculos.Dominio.Shared;
using LocadoraVeiculos.Infra.Logging;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.Aplicacao.FuncionarioModule
{
    public interface IFuncionarioAppService : IAppService<Funcionario>
    {
       
    }

    public class FuncionarioAppService : IFuncionarioAppService
    {
        private readonly IFuncionarioRepository funcionarioRepository;
        private readonly INotificador notificador;

        public FuncionarioAppService(IFuncionarioRepository funcionarioRepository, INotificador notificador)
        {
            this.notificador = notificador;
            this.funcionarioRepository = funcionarioRepository;
        }



        public bool EditarEntidade(int id, Funcionario funcionario)
        {
            var funcionarioAlterado = funcionarioRepository.Editar(id, funcionario);

            if (funcionarioAlterado == false)
            {
                //Log.Logger.Aqui().Information(FuncionarioNaoEditado + IdFuncionarioFormat, id);

                return false;
            }

            return true;
        }

        public bool ExcluirEntidade(int id)
        {
            var funcionarioExcluido = funcionarioRepository.Excluir(id);

            if (funcionarioExcluido == false)
            {
                //Log.Logger.Aqui().Information(FuncionarioNaoExcluido + IdFuncionarioFormat, id);

                return false;
            }

            return true;
        }

        public bool RegistrarNovaEntidade(Funcionario funcionario)
        {
            FuncionarioValidator validations = new FuncionarioValidator();

            var resultado = validations.Validate(funcionario);

            if (!resultado.IsValid)
            {
                foreach (var erro in resultado.Errors)
                {
                    notificador.RegistrarNotificacao(erro.ErrorMessage);
                }
                return false;
            }

            var funcionarioInserido = funcionarioRepository.Inserir(funcionario);

            if (funcionarioInserido == false)
            {
                //Log.Logger.Aqui().Warning(FuncionarioNaoRegistrado + IdFuncionarioFormat, funcionario.Id);

                return false;
            }

            return true;
        }

        public Funcionario SelecionarPorId(int id)
        {
            return funcionarioRepository.SelecionarPorId(id);
        }

        public List<Funcionario> SelecionarTodos()
        {
            return funcionarioRepository.SelecionarTodos();
        }

    }
}
