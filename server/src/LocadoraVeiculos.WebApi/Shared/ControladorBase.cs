using AutoMapper;
using LocadoraVeiculos.Aplicacao.Shared;
using LocadoraVeiculos.Dominio.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocadoraVeiculos.WebApi.Shared
{
    [Route("api/[controller]")]
    [ApiController]
    public class ControladorBase<EListVM, EDetailVM, ECreateVM, EEditVM, Entity > : ControllerBase
    {
        IRepository<Entity, int> repositoryBase;
        IAppService<Entity> appService;
        INotificador notificador;
        IMapper mapper;
        public ControladorBase(IRepository<Entity, int> repositoryBase, IAppService<Entity> appService, IMapper mapper, INotificador notificador)
        {
            this.notificador = notificador;
            this.repositoryBase = repositoryBase;
            this.appService = appService;
            this.mapper = mapper;
            this.notificador = notificador;
        }

        [HttpGet]
        public List<EListVM> GetAll()
        {
            var entidades = repositoryBase.SelecionarTodos();
            
            var viewModel = mapper.Map<List<EListVM>>(entidades);

            return viewModel;
        }


        [HttpGet("{id}")]
        public ActionResult<EDetailVM> Get(int id)
        {
            var entidade = repositoryBase.SelecionarPorId(id);

            if (entidade == null)
                return NotFound(id);

            var viewModel = mapper.Map<EDetailVM>(entidade);

            return Ok(viewModel);
        }

        [HttpPost]
        public ActionResult<ECreateVM> Create(ECreateVM viewModel)
        {
            if (!ModelState.IsValid)
            {
                IEnumerable<ModelError> erros = ModelState.Values.SelectMany(x => x.Errors);

                foreach (var erro in erros)
                {
                    var erroMsg = erro.Exception == null ? erro.ErrorMessage : erro.Exception.Message;

                    notificador.RegistrarNotificacao(erroMsg);
                }

                return BadRequest(new
                {
                    sucess = false,
                    erros = notificador.ObterNotificacoes()
                });
            }

            Entity entidade = mapper.Map<Entity>(viewModel);

            var resultado = appService.RegistrarNovaEntidade(entidade);

            if (resultado == false)
            {
                return BadRequest(new
                {
                    success = false,
                    errors = notificador.ObterNotificacoes()
                });
            }

            return CreatedAtAction(nameof(Create), viewModel);
        }

        [HttpPut("{id}")]
        public ActionResult<EEditVM> Edit(int id, EEditVM viewModel)
        {
            //if (id != viewModel.Id)
            //    return BadRequest();
            if (!ModelState.IsValid)
            {
                IEnumerable<ModelError> erros = ModelState.Values.SelectMany(x => x.Errors);

                foreach (var erro in erros)
                {
                    var erroMsg = erro.Exception == null ? erro.ErrorMessage : erro.Exception.Message;

                    notificador.RegistrarNotificacao(erroMsg);
                }

                return BadRequest(new
                {
                    sucess = false,
                    erros = notificador.ObterNotificacoes()
                });
            }

            Entity entidade = mapper.Map<Entity>(viewModel);

            var resultado = appService.EditarEntidade(id, entidade);

            if (resultado == false)
            {
                return BadRequest(new
                {
                    success = false,
                    errors = notificador.ObterNotificacoes()
                });
            }

            return Ok(viewModel);
        }

        [HttpDelete("{id:int}")]
        public ActionResult<ECreateVM> Delete(int id)
        {
            if (id <= 0)
                return BadRequest("Id não pode ser menor que 0");

            var resultado = appService.ExcluirEntidade(id);

            if (resultado == false)
            {
                return BadRequest(new
                {
                    success = false,
                    errors = notificador.ObterNotificacoes()
                });
            }

            return Ok(id);
        }
    }
}
