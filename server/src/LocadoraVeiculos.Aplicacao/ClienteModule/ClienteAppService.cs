using LocadoraVeiculos.Aplicacao.Shared;
using LocadoraVeiculos.Dominio.ClienteModule;
using LocadoraVeiculos.Dominio.Shared;
using LocadoraVeiculos.Infra.Logging;
using Serilog;
using System.Collections.Generic;

namespace LocadoraVeiculos.Aplicacao.ClienteModule
{
    public interface IClienteAppService : IAppService<Cliente>
    {
    
    }

    public class ClienteAppService : IClienteAppService
    { 

        private readonly IClienteRepository clienteRepository;
        private readonly INotificador notificador;

        public ClienteAppService(IClienteRepository clienteRepository, INotificador notificador)
        {
            this.notificador = notificador;
            this.clienteRepository = clienteRepository;
        }

        private const string IdClienteFormat = "[Id do Cliente: {ClienteId}]";

        private const string ClienteRegistrado_ComSucesso =
            "Entidade registrado com sucesso";

        private const string ClienteNaoRegistrado =
            "Cliente NÃO registrado. Tivemos problemas com a inserção no banco de dados ";

        private const string ClienteNaoEditado =
           "Entidade não editado. Tivemos problemas com a exclusão no banco de dados";

        private const string ClienteEditado_ComSucesso =
            "Entidade editado com sucesso";

        private const string ClienteNaoExcluido =
           "Entidade não excluído. Tivemos problemas com a exclusão no banco de dados";

        private const string ClienteExcluido_ComSucesso =
            "Entidade excluído com sucesso";


        public bool EditarEntidade(int id, Cliente cliente)
        {
            var clienteAlterado = clienteRepository.Editar(id, cliente);

            if (clienteAlterado == false)
            {
                Log.Logger.Aqui().Information(ClienteNaoEditado + IdClienteFormat, id);

                return false;
            }

            return true;
        }

        public bool ExcluirEntidade(int id)
        {
            var clienteExcluido = clienteRepository.Excluir(id);

            if (clienteExcluido == false)
            {
                Log.Logger.Aqui().Information(ClienteNaoExcluido + IdClienteFormat, id);

                return false;
            }

            return true;
        }

        public bool RegistrarNovaEntidade(Cliente cliente)
        {
            ClienteValidator validations = new ClienteValidator();

            var resultado = validations.Validate(cliente);

            if (!resultado.IsValid)
            {
                foreach (var erro in resultado.Errors)
                {
                    notificador.RegistrarNotificacao(erro.ErrorMessage);
                }
                return false;
            }
               

            var clienteInserido = clienteRepository.Inserir(cliente);

            if (clienteInserido == false)
            {
                Log.Logger.Aqui().Warning(ClienteNaoRegistrado + IdClienteFormat, cliente.Id);

                return false;
            }

            return true;
        }

        public Cliente SelecionarPorId(int id)
        {
            return clienteRepository.SelecionarPorId(id);
        }

        public List<Cliente> SelecionarTodos()
        {
            return clienteRepository.SelecionarTodos();
        }


    }
}
