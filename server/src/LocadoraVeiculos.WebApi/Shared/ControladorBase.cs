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
    public class ControladorBase<EListVM, EDetailVM, ECreateVM, EEditVM,Entity > : ControllerBase
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
            var parceiros = repositoryBase.SelecionarTodos();
            
            var viewModel = mapper.Map<List<EListVM>>(parceiros);

            return viewModel;
        }


        [HttpGet("{id}")]
        public ActionResult<EDetailVM> Get(int id)
        {
            var parceiro = repositoryBase.SelecionarPorId(id);

            if (parceiro == null)
                return NotFound(id);

            var viewModel = mapper.Map<EDetailVM>(parceiro);

            return Ok(viewModel);
        }

        [HttpPost]
        public ActionResult<ECreateVM> Create(ECreateVM viewModel)
        {
            Entity parceiro = mapper.Map<Entity>(viewModel);

            var resultado = appService.RegistrarNovaEntidade(parceiro);

            if (resultado == "Parceiro registrado com sucesso")
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

            Entity parceiro = mapper.Map<Entity>(viewModel);

            var resultado = appService.EditarEntidade(id, parceiro);

            if (resultado == "Parceiro editado com sucesso")
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

            if (resultado == "Parceiro excluído com sucesso")
            {
                return Ok(id);
            }

            return NoContent();
        }
    }
}
