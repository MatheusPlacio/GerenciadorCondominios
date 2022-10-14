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
        public DbSet<Usuario> Usuarios { get; set; }
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.CPF).IsRequired().HasMaxLength(30);
            builder.HasIndex(x => x.CPF).IsUnique();
            builder.Property(x => x.Foto).IsRequired();
            builder.Property(x => x.PrimeiroAcesso).IsRequired();
            builder.Property(x => x.Status).IsRequired();

            builder.HasMany(x => x.ProprietariosApartamentos).WithOne(x => x.Proprietario); //HasMany (Muitos), WithOne (um)
            builder.HasMany(x => x.MoradoresApartamentos).WithOne(x => x.Morador); //HasMany (Muitos), WithOne (um)
            builder.HasMany(x => x.Veiculos).WithOne(x => x.Usuario); //HasMany (Muitos), WithOne (um)
            builder.HasMany(x => x.Eventos).WithOne(x => x.Usuario); //HasMany (Muitos), WithOne (um)
            builder.HasMany(x => x.Pagamentos).WithOne(x => x.Usuario); //HasMany (Muitos), WithOne (um)
            builder.HasMany(x => x.Servicos).WithOne(x => x.Usuario); //HasMany (Muitos), WithOne (um)
        }
    }
}
