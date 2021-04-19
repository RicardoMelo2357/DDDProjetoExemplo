using AutoMapper;
using Dominio.Interfaces.Repositorio.Usuario;
using Dominio.Interfaces.Servicos.Usuario;
using Dominio.Servicos.Usuario;
using Infra.Persistencia;
using Infra.Persistencia.Repositorios.Usuario;
using Infra.Transactions;
using prmToolkit.NotificationPattern;
using System.Data.Entity;
using Unity;
using Unity.Lifetime;
using Utilidade.AutoMapper;

namespace IoC.Unity
{
    public static class DependencyResolver
    {
        public static void Resolve(UnityContainer container)
        {
            Configuration(container);
            Servicos(container);
            Repositorios(container);
        }

        private static void Configuration(UnityContainer container)
        {
            container.RegisterInstance(new Configuracao().Configure(container));
            container.RegisterType<DbContext, Contexto>(new HierarchicalLifetimeManager());
            container.RegisterType<IUnitOfWork, UnitOfWork>(new HierarchicalLifetimeManager());
            container.RegisterType<INotifiable, Notifiable>(new HierarchicalLifetimeManager());
        }

        private static void Servicos(UnityContainer container)
        {
            container.RegisterType<IServicoUsuario, ServicoUsuario>(new HierarchicalLifetimeManager());
        }

        private static void Repositorios(UnityContainer container)
        {
            container.RegisterType<IRepositorioUsuario, RepositorioUsuario>(new HierarchicalLifetimeManager());
        }
    }
}
