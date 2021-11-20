using LocadoraVeiculos.Aplicacao.Shared;
using LocadoraVeiculos.Dominio.ClienteModule;
using LocadoraVeiculos.Infra.Logging;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.Aplicacao.CondutorModule
{
    public interface ICondutorAppService : IAppService<Condutor>
    {
     
    }

    public class CondutorAppService : ICondutorAppService
    {
        private readonly ICondutorRepository condutorRepository;

        public CondutorAppService(ICondutorRepository condutorRepository)
        {
            this.condutorRepository = condutorRepository;
        }

        private const string IdCondutorFormat = "[Id do Condutor: {CondutorId}]";

        private const string CondutorRegistrado_ComSucesso =
            "Entidade registrado com sucesso";

        private const string CondutorNaoRegistrado =
            "Condutor não registrado. Tivemos problemas com a inserção no banco de dados ";

        private const string CondutorNaoEditado =
           "Condutor não editado. Tivemos problemas com a exclusão no banco de dados";

        private const string CondutorEditado_ComSucesso =
            "Entidade editado com sucesso";

        private const string CondutorNaoExcluido =
           "Condutor não excluído. Tivemos problemas com a exclusão no banco de dados";

        private const string CondutorExcluido_ComSucesso =
            "Entidade excluído com sucesso";


        public string EditarEntidade(int id, Condutor condutor)
        {
            var condutorAlterado = condutorRepository.Editar(id, condutor);

            if (condutorAlterado == false)
            {
                Log.Logger.Aqui().Information(CondutorNaoEditado + IdCondutorFormat, id);

                return CondutorNaoEditado;
            }

            return CondutorEditado_ComSucesso;
        }

        public string ExcluirEntidade(int id)
        {
            var condutorExcluido = condutorRepository.Excluir(id);

            if (condutorExcluido == false)
            {
                Log.Logger.Aqui().Information(CondutorNaoExcluido + IdCondutorFormat, id);

                return CondutorNaoExcluido;
            }

            return CondutorExcluido_ComSucesso;
        }

        public string RegistrarNovaEntidade(Condutor condutor)
        {
            var resultado = condutor.Validar();

            if (resultado != "ESTA_VALIDO")
                return resultado;

            var condutorInserido = condutorRepository.Inserir(condutor);

            if (condutorInserido == false)
            {
                Log.Logger.Aqui().Warning(CondutorNaoRegistrado + IdCondutorFormat, condutor.Id);

                return CondutorNaoRegistrado;
            }

            return CondutorRegistrado_ComSucesso;
        }

        public Condutor SelecionarPorId(int id)
        {
            return condutorRepository.SelecionarPorId(id);
        }

        public List<Condutor> SelecionarTodos()
        {
            return condutorRepository.SelecionarTodos();
        }


    }
}
