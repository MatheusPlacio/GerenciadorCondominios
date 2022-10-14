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
    public class EventoMap : IEntityTypeConfiguration<Eventos>
    {
        public DbSet<Eventos> Eventos { get; set; }
        public void Configure(EntityTypeBuilder<Eventos> builder)
        {
            builder.HasKey(x => x.EventoId);
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Data).IsRequired();
            builder.Property(x => x.UsuarioId).IsRequired();

            builder.HasOne(x => x.Usuario).WithMany(x => x.Eventos).HasForeignKey(x => x.UsuarioId);
        }
    }
}
