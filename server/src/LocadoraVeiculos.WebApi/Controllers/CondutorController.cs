using AutoMapper;
using LocadoraVeiculos.Aplicacao.CondutorModule;
using LocadoraVeiculos.Aplicacao.Shared;
using LocadoraVeiculos.Dominio.ClienteModule;
using LocadoraVeiculos.Dominio.Shared;
using LocadoraVeiculos.WebApi.Shared;
using LocadoraVeiculos.WebApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocadoraVeiculos.WebApi.Controllers
{
    public class CondutorController : ControladorBase<CondutorListViewModel, CondutorDetailsViewModel, CondutorCreateViewModel, CondutorEditViewModel, Condutor>
    {
        public CondutorController(ICondutorRepository condutorRepository, ICondutorAppService condutorAppService, IMapper mapper, INotificador notificador
            ) : base(condutorRepository, condutorAppService, mapper, notificador)
        {
        }
    }
}
