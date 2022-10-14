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
    public class ServicoMap : IEntityTypeConfiguration<Servico>
    {
        public DbSet<Servico> Servicos { get; set; }
        public void Configure(EntityTypeBuilder<Servico> builder)
        {
            builder.HasKey(x => x.ServicoId);
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(30);
            builder.Property(x => x.Valor).IsRequired();
            builder.Property(x => x.Status).IsRequired();
            builder.Property(x => x.UsuarioId).IsRequired();

            builder.HasOne(x => x.Usuario).WithMany(x => x.Servicos).HasForeignKey(x => x.UsuarioId);
            builder.HasMany(x => x.ServicoPredios).WithOne(x => x.Servico);
        }
    }
}
