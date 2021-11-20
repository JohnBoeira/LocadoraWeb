using Autofac;
using AutoMapper;
using LocadoraVeiculos.Aplicacao.ClienteModule;
using LocadoraVeiculos.Aplicacao.CupomModule;
using LocadoraVeiculos.Aplicacao.FuncionarioModule;
using LocadoraVeiculos.Dominio.ClienteModule;
using LocadoraVeiculos.Dominio.CupomModule;
using LocadoraVeiculos.Dominio.FuncionarioModule;
using LocadoraVeiculos.Infra.ORM;
using LocadoraVeiculos.Infra.ORM.ClienteModule;
using LocadoraVeiculos.Infra.ORM.CupomModule;
using LocadoraVeiculos.Infra.ORM.FuncionarioModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocadoraVeiculos.WebApi.Config.AutofacConfig
{
    public class ContainerModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<LocadoraDbContext>().InstancePerLifetimeScope();

            builder.RegisterType<CupomOrmDao>().As<ICupomRepository>();
            builder.RegisterType<ParceiroOrmDao>().As<IParceiroRepository>();

            builder.RegisterType<CupomAppService>().As<ICupomAppService>();
            builder.RegisterType<ParceiroAppService>().As<IParceiroAppService>();

            builder.RegisterType<FuncionarioOrmDao>().As<IFuncionarioRepository>();
            builder.RegisterType<FuncionarioAppService>().As<IFuncionarioAppService>();

            builder.RegisterType<ClienteOrmDao>().As<IClienteRepository>();
            builder.RegisterType<ClienteAppService>().As<IClienteAppService>();

            builder.RegisterType<Mapper>().As<IMapper>();

        }
    }
}
