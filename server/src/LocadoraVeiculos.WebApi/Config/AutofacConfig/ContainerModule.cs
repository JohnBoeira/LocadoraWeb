﻿using Autofac;
using AutoMapper;
using LocadoraVeiculos.Aplicacao.CupomModule;
using LocadoraVeiculos.Dominio.CupomModule;
using LocadoraVeiculos.Infra.ORM;
using LocadoraVeiculos.Infra.ORM.CupomModule;
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

            builder.RegisterType<Mapper>().As<IMapper>();

        }
    }
}