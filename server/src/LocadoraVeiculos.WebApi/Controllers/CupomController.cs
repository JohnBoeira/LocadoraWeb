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
    public class CupomController : ControladorBase<CupomListViewModel, CupomDetailsViewModel, CupomCreateViewModel, CupomEditViewModel, Cupom>
    {
        public CupomController(ICupomRepository cupomRepository, ICupomAppService cupomAppService, IMapper mapper, INotificador notificador) : base(cupomRepository, cupomAppService, mapper, notificador)
        {
        }
    }
}
