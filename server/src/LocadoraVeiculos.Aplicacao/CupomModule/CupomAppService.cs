using LocadoraVeiculos.Aplicacao.Shared;
using LocadoraVeiculos.Dominio.CupomModule;
using LocadoraVeiculos.Dominio.Shared;
using LocadoraVeiculos.Infra.Logging;
using Serilog;
using System;
using System.Collections.Generic;

namespace LocadoraVeiculos.Aplicacao.CupomModule
{
    public interface ICupomAppService: IAppService<Cupom>
    {
        List<Cupom> SelecionarCuponsAtivos(DateTime date);
        
    }

    public class CupomAppService : ICupomAppService
    {
        private readonly ICupomRepository cupomRepository;
        private readonly INotificador notificador;

        public CupomAppService(ICupomRepository cupomRepository, INotificador notificador)
        {
            this.cupomRepository = cupomRepository;
            this.notificador = notificador;
        }

        private const string IdCupomFormat = "[Id do Cupom: {CupomId}]";

        private const string CupomRegistrado_ComSucesso =
            "Entidade registrado com sucesso";

        private const string CupomNaoRegistrado =
            "Cupom NÃO registrado. Tivemos problemas com a inserção no banco de dados ";

        private const string CupomNaoEditado =
           "Cupom não editado. Tivemos problemas com a exclusão no banco de dados";

        private const string CupomEditado_ComSucesso =
            "Entidade editado com sucesso";

        private const string CupomNaoExcluido =
           "Cupom não excluído. Tivemos problemas com a exclusão no banco de dados";

        private const string CupomExcluido_ComSucesso =
            "Entidade excluído com sucesso";


        public bool EditarEntidade(int id, Cupom cupom)
        {
            var cupomAlterado = cupomRepository.Editar(id, cupom);

            if (cupomAlterado == false)
            {
                Log.Logger.Aqui().Information(CupomNaoEditado + IdCupomFormat, id);

                return false;
            }

            return true;
        }

        public bool ExcluirEntidade(int id)
        {
            var cupomExcluido = cupomRepository.Excluir(id);

            if (cupomExcluido == false)
            {
                Log.Logger.Aqui().Information(CupomNaoExcluido + IdCupomFormat, id);

                return false;
            }

            return true;
        }

        public bool RegistrarNovaEntidade(Cupom cupom)
        {
            CupomValidator cupomValidator = new CupomValidator();

            var resultado = cupomValidator.Validate(cupom);

            if (!resultado.IsValid)
            {
                foreach (var erro in resultado.Errors)
                {
                    notificador.RegistrarNotificacao(erro.ErrorMessage);
                }
                return false;
            }

            var cupomInserido = cupomRepository.Inserir(cupom);

            if (cupomInserido == false)
            {
                Log.Logger.Aqui().Warning(CupomNaoRegistrado + IdCupomFormat, cupom.Id);

                return false;
            }

            return true;
        }

        public Cupom SelecionarPorId(int id)
        {
            return cupomRepository.SelecionarPorId(id);
        }

        public List<Cupom> SelecionarTodos()
        {
            return cupomRepository.SelecionarTodos();
        }

        public List<Cupom> SelecionarCuponsAtivos(DateTime data)
        {
            return cupomRepository.SelecionarCuponsAtivos(data);
        }


    }
}
