using AutoMapper;
using LocadoraVeiculos.Aplicacao.Shared;
using LocadoraVeiculos.Dominio.Shared;
using Microsoft.AspNetCore.Mvc;
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
        IMapper mapper;
        public ControladorBase(IRepository<Entity, int> repositoryBase, IAppService<Entity> appService, IMapper mapper)
        {
            this.repositoryBase = repositoryBase;
            this.appService = appService;
            this.mapper = mapper;
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
            Entity entidade = mapper.Map<Entity>(viewModel);

            var resultado = appService.RegistrarNovaEntidade(entidade);

            if (resultado == "Entidade registrado com sucesso")
            {
                return CreatedAtAction(nameof(Create), viewModel);
            }

            return NoContent();
        }

        [HttpPut("{id}")]
        public ActionResult<EEditVM> Edit(int id, EEditVM viewModel)
        {
            //if (id != viewModel.Id)
            //    return BadRequest();

            Entity entidade = mapper.Map<Entity>(viewModel);

            var resultado = appService.EditarEntidade(id, entidade);

            if (resultado == "Entidade editado com sucesso")
            {
                return Ok(viewModel);
            }

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public ActionResult<ECreateVM> Delete(int id)
        {
            if (id <= 0)
                return BadRequest("Id não pode ser menor que 0");

            var resultado = appService.ExcluirEntidade(id);

            if (resultado == "Entidade excluído com sucesso")
            {
                return Ok(id);
            }

            return NoContent();
        }
    }
}
