using AutoMapper;
using LocadoraVeiculos.Aplicacao.FuncionarioModule;
using LocadoraVeiculos.Dominio.FuncionarioModule;
using LocadoraVeiculos.Dominio.Shared;
using LocadoraVeiculos.WebApi.Shared;
using LocadoraVeiculos.WebApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocadoraVeiculos.WebApi.Controllers
{
    public class FuncionarioController : ControladorBase<FuncionarioListViewModel, FuncionarioDetailsViewModel, FuncionarioCreateViewModel, FuncionarioEditViewModel, Funcionario>
    {
        public FuncionarioController(IFuncionarioRepository funcionarioRepository, IFuncionarioAppService funcionarioAppService, IMapper mapper, INotificador notificador) : base(funcionarioRepository, funcionarioAppService, mapper, notificador)
        {

        }
    }
}
