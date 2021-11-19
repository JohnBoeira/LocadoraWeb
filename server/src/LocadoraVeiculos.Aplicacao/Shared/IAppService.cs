using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.Aplicacao.Shared
{
    public interface IAppService<TEntity>
    {
        List<TEntity> SelecionarTodos();
        string RegistrarNovaEntidade(TEntity entidade);
        TEntity SelecionarPorId(int id);
        string ExcluirEntidade(int id);

        string EditarEntidade(int id, TEntity parceiro);
    }
}
