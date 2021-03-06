using LocadoraVeiculos.Aplicacao.Shared;
using LocadoraVeiculos.Dominio.CupomModule;
using LocadoraVeiculos.Dominio.Shared;
using LocadoraVeiculos.Infra.Logging;
using Serilog;
using System.Collections.Generic;

namespace LocadoraVeiculos.Aplicacao.CupomModule
{
    public interface IParceiroAppService : IAppService<Parceiro>
    {
        
    }

    public class ParceiroAppService : IParceiroAppService
    {
        private const string IdParceiroFormat = "[Id do Parceiro: {ParceiroId}]";

        private const string ParceiroRegistrado_ComSucesso =
            "Parceiro registrado com sucesso";

        private const string ParceiroNaoRegistrado =
            "Parceiro NÃO registrado. Tivemos problemas com a inserção no banco de dados ";


        private const string ParceiroNaoEditado =
         "Parceiro não editado. Tivemos problemas com a exclusão no banco de dados";

        private const string ParceiroEditado_ComSucesso =
            "Parceiro editado com sucesso";

        private const string ParceiroNaoExcluido =
           "Parceiro não excluído. Tivemos problemas com a exclusão no banco de dados";

        private const string ParceiroExcluido_ComSucesso =
            "Parceiro excluído com sucesso";


        private readonly IParceiroRepository parceiroRepository;
        private readonly INotificador notificador;

        public ParceiroAppService(IParceiroRepository parceiroRepository, INotificador notificador)
        {
            this.notificador = notificador;
            this.parceiroRepository = parceiroRepository;
        }

       

        public bool EditarEntidade(int id, Parceiro parceiro)
        {
            var cupomAlterado = parceiroRepository.Editar(id, parceiro);

            if (cupomAlterado == false)
            {
                Log.Logger.Aqui().Information(ParceiroNaoEditado + IdParceiroFormat, id);

                return false;
            }

            return true;
        }

        public bool ExcluirEntidade(int id)
        {
            var parceiroExcluido = parceiroRepository.Excluir(id);

            if (parceiroExcluido == false)
            {
                Log.Logger.Aqui().Information(ParceiroNaoExcluido + IdParceiroFormat, id);

                return false;
            }

            return true;
        }

        public bool RegistrarNovaEntidade(Parceiro entidade)
        {
            ParceiroValidator validations = new ParceiroValidator();

            var resultado = validations.Validate(entidade);

            if (!resultado.IsValid)
            {
                foreach (var erro in resultado.Errors)
                {
                    notificador.RegistrarNotificacao(erro.ErrorMessage);
                }
                return false;
            }

            var parceiroInserido = parceiroRepository.Inserir(entidade);

            if (parceiroInserido == false)
            {
                Log.Logger.Aqui().Warning(ParceiroNaoRegistrado + IdParceiroFormat, entidade.Id);

                return false;
            }

            return true;
        }    

        public Parceiro SelecionarPorId(int id)
        {
            return parceiroRepository.SelecionarPorId(id);
        }

        public List<Parceiro> SelecionarTodos()
        {
            return parceiroRepository.SelecionarTodos();
        }
    }
}
