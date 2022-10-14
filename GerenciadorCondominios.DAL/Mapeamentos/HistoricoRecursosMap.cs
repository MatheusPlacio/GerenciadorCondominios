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
    public class HistoricoRecursosMap : IEntityTypeConfiguration<HistoricoRecursos>
    {
        public DbSet<HistoricoRecursos> HistoricoRecursos{ get; set; }
        public void Configure(EntityTypeBuilder<HistoricoRecursos> builder)
        {
            builder.HasKey(x => x.HistoricoRecursosId);
            builder.Property(x => x.Valor).IsRequired();
            builder.Property(x => x.Tipo).IsRequired();
            builder.Property(x => x.Dia).IsRequired();
            builder.Property(x => x.Ano).IsRequired();
            builder.Property(x => x.MesId).IsRequired();

            builder.HasOne(x => x.Mes).WithMany(x => x.HistoricoRecursos).HasForeignKey(x => x.MesId);
        }
    }
}
