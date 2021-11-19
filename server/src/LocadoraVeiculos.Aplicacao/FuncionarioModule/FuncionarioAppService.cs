using LocadoraVeiculos.Aplicacao.Shared;
using LocadoraVeiculos.Dominio.FuncionarioModule;
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

        public FuncionarioAppService(IFuncionarioRepository funcionarioRepository)
        {
            this.funcionarioRepository = funcionarioRepository;
        }

        private const string IdFuncionarioFormat = "[Id do Funcionario: {FuncionarioId}]";

        private const string FuncionarioRegistrado_ComSucesso =
            "Entidade registrado com sucesso";

        private const string FuncionarioNaoRegistrado =
            "Entidade NÃO registrado. Tivemos problemas com a inserção no banco de dados ";

        private const string FuncionarioNaoEditado =
           "Entidade não editado. Tivemos problemas com a exclusão no banco de dados";

        private const string FuncionarioEditado_ComSucesso =
            "Entidade editado com sucesso";

        private const string FuncionarioNaoExcluido =
           "Funcionario não excluído. Tivemos problemas com a exclusão no banco de dados";

        private const string FuncionarioExcluido_ComSucesso =
            "Entidade excluído com sucesso";


        public string EditarEntidade(int id, Funcionario funcionario)
        {
            var funcionarioAlterado = funcionarioRepository.Editar(id, funcionario);

            if (funcionarioAlterado == false)
            {
                Log.Logger.Aqui().Information(FuncionarioNaoEditado + IdFuncionarioFormat, id);

                return FuncionarioNaoEditado;
            }

            return FuncionarioEditado_ComSucesso;
        }

        public string ExcluirEntidade(int id)
        {
            var funcionarioExcluido = funcionarioRepository.Excluir(id);

            if (funcionarioExcluido == false)
            {
                Log.Logger.Aqui().Information(FuncionarioNaoExcluido + IdFuncionarioFormat, id);

                return FuncionarioNaoExcluido;
            }

            return FuncionarioExcluido_ComSucesso;
        }

        public string RegistrarNovaEntidade(Funcionario funcionario)
        {
            var resultado = funcionario.Validar();

            if (resultado != "ESTA_VALIDO")
                return resultado;

            var funcionarioInserido = funcionarioRepository.Inserir(funcionario);

            if (funcionarioInserido == false)
            {
                Log.Logger.Aqui().Warning(FuncionarioNaoRegistrado + IdFuncionarioFormat, funcionario.Id);

                return FuncionarioNaoRegistrado;
            }

            return FuncionarioRegistrado_ComSucesso;
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
