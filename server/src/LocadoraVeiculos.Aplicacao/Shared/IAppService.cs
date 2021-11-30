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
        bool RegistrarNovaEntidade(TEntity entidade);
        TEntity SelecionarPorId(int id);
        bool ExcluirEntidade(int id);

        bool EditarEntidade(int id, TEntity parceiro);
       
    }
}
