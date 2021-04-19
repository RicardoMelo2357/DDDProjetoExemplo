using System.Data.Entity.ModelConfiguration;

namespace Infra.Persistencia.Map.Usuario
{
    public class MapUsuario : EntityTypeConfiguration<Dominio.Entidades.Usuario.Usuario>
    {
        public MapUsuario()
        {
            ToTable("Usuario");

            Property(p => p.Id).HasColumnName("UsuarioId").IsRequired();
            Property(p => p.Nome).HasMaxLength(100).IsRequired();
            Property(p => p.Senha).HasMaxLength(100).IsRequired();
            Property(p => p.Email).HasMaxLength(100).IsRequired();
        }
    }
}
