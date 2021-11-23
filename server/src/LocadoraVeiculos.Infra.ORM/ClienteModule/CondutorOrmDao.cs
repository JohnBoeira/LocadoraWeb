using LocadoraVeiculos.Dominio.ClienteModule;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LocadoraVeiculos.Infra.ORM.ClienteModule
{
    public class CondutorOrmDao : RepositoryOrmBase<Condutor, int>, ICondutorRepository
    {
        public CondutorOrmDao(LocadoraDbContext db) : base(db)
        {
        }

        public override List<Condutor> SelecionarTodos()
        {
            return dbSet
                    .Include(x => x.Cliente)
                    .ToList();
        }

        public List<Condutor> SelecionarTodos(bool carregarClientes = true)
        {
            return SelecionarTodos();

           
        }
    }
}
