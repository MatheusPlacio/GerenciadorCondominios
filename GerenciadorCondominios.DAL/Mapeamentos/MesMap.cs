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
    public class MesMap : IEntityTypeConfiguration<Mes>
    {
        public DbSet<Mes> Meses { get; set; }
        public void Configure(EntityTypeBuilder<Mes> builder)
        {
            builder.HasKey(x => x.MesId); //Chave primária
            builder.Property(x => x.MesId).ValueGeneratedNever(); //Não gera valor automatico

            builder.Property(x => x.Nome).IsRequired().HasMaxLength(30);
            builder.HasIndex(x => x.Nome).IsUnique(); //Nesse caso o nome do MÊS é unico

            builder.HasMany(x => x.Alugueis).WithOne(x => x.Mes); //HasMany (Muitos), WithOne (um)
            builder.HasMany(x => x.HistoricoRecursos).WithOne(x => x.Mes); //HasMany (Muitos), WithOne (um)

            builder.HasData(
                new Mes
                {
                    MesId = 1,
                    Nome = "Janeiro"
                },

                new Mes
                {
                    MesId = 2,
                    Nome = "Fevereiro"
                },

                new Mes
                {
                    MesId = 3,
                    Nome = "Março"
                },

                new Mes
                {
                    MesId = 4,
                    Nome = "Abril"
                },

                new Mes
                {
                    MesId = 5,
                    Nome = "Maio"
                },

                new Mes
                {
                    MesId = 6,
                    Nome = "Junho"
                },

                new Mes
                {
                    MesId = 7,
                    Nome = "Julho"
                },

                new Mes
                {
                    MesId = 8,
                    Nome = "Agosto"
                },

                new Mes
                {
                    MesId = 9,
                    Nome = "Setembro"
                },

                new Mes
                {
                    MesId = 10,
                    Nome = "Outubro"
                },

                new Mes
                {
                    MesId = 11,
                    Nome = "Novembro"
                },

                new Mes
                {
                    MesId = 12,
                    Nome = "Dezembro"
                });
        }
    }
}
