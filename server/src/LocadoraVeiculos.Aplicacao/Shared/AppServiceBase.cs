using FluentValidation;
using LocadoraVeiculos.Dominio;
using LocadoraVeiculos.Dominio.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.Aplicacao.Shared
{
    public class AppServiceBase : IAppService<EntidadeBase<int>>
    {
        private readonly IRepository<EntidadeBase<int>, int> entidadeRepository;
        private readonly INotificador notificador;
        //private readonly AbstractValidator<EntidadeBase<int>> validations;

        public AppServiceBase(IRepository<EntidadeBase<int>, int> EntidadeRepository, INotificador notificador)
        {
            //this.validations = validations;
            this.notificador = notificador;
            this.entidadeRepository = EntidadeRepository;
        }

        public bool EditarEntidade(int id, EntidadeBase<int> entidade)
        {
            var EntidadeAlterado = entidadeRepository.Editar(id, entidade);

            if (EntidadeAlterado == false)
            {
                //Log.Logger.Aqui().Information(EntidadeNaoEditado + IdEntidadeFormat, id);

                return false;
            }

            return true;
        }

        public bool ExcluirEntidade(int id)
        {
            var entidadeExcluido = entidadeRepository.Excluir(id);

            if (entidadeExcluido == false)
            {
                //Log.Logger.Aqui().Information(entidadeNaoExcluido + IdentidadeFormat, id);

                return false;
            }

            return true;
        }

        public bool RegistrarNovaEntidade(EntidadeBase<int> entidade)
        {

            //var resultado = validations.Validate(entidade);

            //if (!resultado.IsValid)
            //{
            //    foreach (var erro in resultado.Errors)
            //    {
            //        notificador.RegistrarNotificacao(erro.ErrorMessage);
            //    }
            //    return false;
            //}

            var entidadeInserido = entidadeRepository.Inserir(entidade);

            if (entidadeInserido == false)
            {
                //Log.Logger.Aqui().Warning(entidadeNaoRegistrado + IdentidadeFormat, entidade.Id);

                return false;
            }

            return true;
        }

        public EntidadeBase<int> SelecionarPorId(int id)
        {
            return entidadeRepository.SelecionarPorId(id);
        }

        public List<EntidadeBase<int>> SelecionarTodos()
        {
            return entidadeRepository.SelecionarTodos();
        }
    }
}
