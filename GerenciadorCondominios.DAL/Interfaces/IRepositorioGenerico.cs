using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorCondominios.DAL.Interfaces
{
    public interface IRepositorioGenerico<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> PegarTodos();
        Task<TEntity> PegarPeloId(int id);
        Task<TEntity> PegarPeloId(string id);
        Task Inserir(TEntity entity);
        Task Atualizar(TEntity entity);
        Task Exlcuir(TEntity entity);
        Task Exlcuir(int id);
        Task Exlcuir(string id);

    }
}
