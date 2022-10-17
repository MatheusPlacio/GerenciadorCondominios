using GerenciadorCondominios.BLL.Models;
using GerenciadorCondominios.DAL.Mapeamentos;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorCondominios.DAL.Context
{
    public class DataContext : IdentityDbContext<Usuario, Funcao, string>
    {

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        { }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new AluguelMap());
            builder.ApplyConfiguration(new ApartamentoMap());
            builder.ApplyConfiguration(new EventoMap());
            builder.ApplyConfiguration(new FuncaoMap());
            builder.ApplyConfiguration(new HistoricoRecursosMap());
            builder.ApplyConfiguration(new MesMap());
            builder.ApplyConfiguration(new ServicoMap());
            builder.ApplyConfiguration(new ServicoPrediosMap());
            builder.ApplyConfiguration(new UsuarioMap());
            builder.ApplyConfiguration(new VeiculoMap());
        }
    }
}
