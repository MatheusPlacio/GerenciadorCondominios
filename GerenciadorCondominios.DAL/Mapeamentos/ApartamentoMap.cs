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
    public class ApartamentoMap : IEntityTypeConfiguration<Apartamento>
    {
        public DbSet<Apartamento> Apartamentos { get; set; }
        public void Configure(EntityTypeBuilder<Apartamento> builder)
        {
            builder.HasKey(x => x.ApartamentoId);
            builder.Property(x => x.Numero).IsRequired();
            builder.Property(x => x.Andar).IsRequired();
            builder.Property(x => x.Foto).IsRequired();
            builder.Property(x => x.ProprietarioId).IsRequired();
            builder.Property(x => x.MoradorId).IsRequired(false);

            builder.HasOne(x => x.Proprietario).WithMany(x => x.ProprietariosApartamentos)
                .HasForeignKey(x => x.ProprietarioId)
                .OnDelete(DeleteBehavior.NoAction); 

            builder.HasOne(x => x.Morador).WithMany(x => x.MoradoresApartamentos)
                .HasForeignKey(x => x.MoradorId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
