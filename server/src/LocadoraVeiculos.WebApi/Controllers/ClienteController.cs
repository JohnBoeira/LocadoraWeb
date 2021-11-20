using AutoMapper;
using LocadoraVeiculos.Aplicacao.ClienteModule;
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
    public class ClienteController : ControladorBase<ClienteListViewModel, ClienteDetailsViewModel, ClienteCreateViewModel, ClienteEditViewModel, Cliente>
    {
        public ClienteController(IClienteRepository clienteRepository, IClienteAppService clienteAppService, IMapper mapper) : base(clienteRepository, clienteAppService, mapper)
        {
        }
    }
}
