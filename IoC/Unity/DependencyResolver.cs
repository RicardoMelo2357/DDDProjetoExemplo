﻿using Dominio.Interfaces.Repositorio.Base;
using Dominio.Interfaces.Repositorio.Usuario;
using Dominio.Interfaces.Servicos.Usuario;
using Dominio.Servicos.Usuario;
using Infra.Persistencia;
using Infra.Persistencia.Repositorios.Base;
using Infra.Persistencia.Repositorios.Usuario;
using IoC.AutoMapper;
using prmToolkit.NotificationPattern;
using System.Data.Entity;
using Unity;
using Unity.Lifetime;


namespace IoC.Unity
{
    public static class DependencyResolver
    {
        public static void Resolve(UnityContainer container)
        {
            Configuracao(container);
            Servicos(container);
            Repositorios(container);
        }

        private static void Configuracao(UnityContainer container)
        {
            container.RegisterType<DbContext, Contexto>(new HierarchicalLifetimeManager());
            container.RegisterType<INotifiable, Notifiable>(new HierarchicalLifetimeManager());
            container.RegisterInstance(new Configuracao().Configure(container));
        }

        private static void Servicos(UnityContainer container)
        {
            container.RegisterType<IServicoUsuario, ServicoUsuario>(new HierarchicalLifetimeManager());
        }

        private static void Repositorios(UnityContainer container)
        {
            container.RegisterType(typeof(IRepositorioBase<,>), typeof(RepositorioBase<,>));
            container.RegisterType<IRepositorioUsuario, RepositorioUsuario>(new HierarchicalLifetimeManager());
        }
    }
}
