using AutoMapper;
using LocadoraVeiculos.Aplicacao.CupomModule;
using LocadoraVeiculos.Aplicacao.Shared;
using LocadoraVeiculos.Dominio.CupomModule;
using LocadoraVeiculos.Dominio.Shared;
using LocadoraVeiculos.Infra.ORM;
using LocadoraVeiculos.Infra.ORM.CupomModule;
using LocadoraVeiculos.WebApi.Shared;
using LocadoraVeiculos.WebApi.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocadoraVeiculos.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParceiroController : ControladorBase<ParceiroListViewModel, ParceiroDetailsViewModel, ParceiroCreateViewModel, ParceiroEditViewModel, Parceiro>
    {
        public ParceiroController(IParceiroRepository parceiroRepository, IParceiroAppService parceiroAppService, IMapper mapper, INotificador not
            ) : base(parceiroRepository, parceiroAppService, mapper, notificador)
        {
        }
    }


}
