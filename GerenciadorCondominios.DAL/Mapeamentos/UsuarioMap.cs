using GerenciadorCondominios.BLL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorCondominios.DAL.Mapeamentos
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.CPF).IsRequired().HasMaxLength(30);
            builder.HasIndex(x => x.CPF).IsUnique();
            builder.Property(x => x.Foto).IsRequired();
            builder.Property(x => x.PrimeiroAcesso).IsRequired();
            builder.Property(x => x.Status).IsRequired();

            builder.HasMany(x => x.ProprietariosApartamentos).WithOne(x => x.Proprietario);
            builder.HasMany(x => x.MoradoresApartamentos).WithOne(x => x.Morador); // 1 morador pode ter varios Ap, e o AP 1 morador
        }
    }
}
