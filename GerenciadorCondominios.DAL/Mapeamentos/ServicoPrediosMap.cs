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
    public class ServicoPrediosMap : IEntityTypeConfiguration<ServicoPredio>
    {
        public DbSet<ServicoPredio> ServicoPredios { get; set; }
        public void Configure(EntityTypeBuilder<ServicoPredio> builder)
        {
            builder.HasKey(x => x.ServicoPredioId);
            builder.Property(x => x.DataExecucao).IsRequired();
            builder.Property(x => x.ServicoId).IsRequired();

            builder.HasOne(x => x.Servico).WithMany(x => x.ServicoPredios).HasForeignKey(x => x.ServicoId);
        }
    }
}
