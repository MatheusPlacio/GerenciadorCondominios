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
    public class AluguelMap : IEntityTypeConfiguration<Aluguel>
    {
        public DbSet<Aluguel> Alugueis { get; set; }
        public void Configure(EntityTypeBuilder<Aluguel> builder)
        {
            builder.HasKey(x => x.AluguelId);
            builder.Property(x => x.Valor).IsRequired();
            builder.Property(x => x.MesId).IsRequired();
            builder.Property(x => x.Ano).IsRequired();

            builder.HasOne(x => x.Mes).WithMany(x => x.Alugueis).HasForeignKey(x => x.MesId);
            builder.HasMany(x => x.Pagamentos).WithOne(x => x.Aluguel);
        }
    }
}
