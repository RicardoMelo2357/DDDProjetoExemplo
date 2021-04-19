using Dominio.Entidades.Usuario;
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Infra.Persistencia
{
    public class Contexto : DbContext
    {
        public Contexto() : base("ProjetoExemplo")
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
        }

        public IDbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Properties<string>().Configure(p => p.HasColumnType("varchar"));
            modelBuilder.Configurations.AddFromAssembly(typeof(Contexto).Assembly);

            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            AddTimestamps();
            return base.SaveChanges();
        }

        private void AddTimestamps()
        {
            foreach (var entry in ChangeTracker.Entries())
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataInclusao").CurrentValue = DateTime.Now;
                }

                if (entry.State != EntityState.Modified) continue;
                entry.Property("DataAlteracao").CurrentValue = DateTime.Now;
            }
        }
    }
}
