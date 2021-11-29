using Autofac;
using AutoMapper;
using LocadoraVeiculos.Aplicacao.ClienteModule;
using LocadoraVeiculos.Aplicacao.CondutorModule;
using LocadoraVeiculos.Aplicacao.CupomModule;
using LocadoraVeiculos.Aplicacao.FuncionarioModule;
using LocadoraVeiculos.Aplicacao.TaxaModule;
using LocadoraVeiculos.Dominio.ClienteModule;
using LocadoraVeiculos.Dominio.CupomModule;
using LocadoraVeiculos.Dominio.FuncionarioModule;
using LocadoraVeiculos.Dominio.Shared;
using LocadoraVeiculos.Dominio.TaxaModule;
using LocadoraVeiculos.Infra.ORM;
using LocadoraVeiculos.Infra.ORM.ClienteModule;
using LocadoraVeiculos.Infra.ORM.CupomModule;
using LocadoraVeiculos.Infra.ORM.FuncionarioModule;
using LocadoraVeiculos.Infra.ORM.TaxaModule;
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

            builder.RegisterType<CondutorOrmDao>().As<ICondutorRepository>();
            builder.RegisterType<CondutorAppService>().As<ICondutorAppService>();

            builder.RegisterType<Notificador>().As<INotificador>();

            builder.RegisterType<TaxaOrmDao>().As<ITaxaRepository>();
            builder.RegisterType<TaxaAppService>().As<ITaxaAppService>();


            builder.RegisterType<Mapper>().As<IMapper>();

        }
    }
}
