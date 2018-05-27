using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BolaoSocial.Shared.Contracts;
using BolaoSocial.Shared.Repositories;

namespace BolaoSocial.Shared.Services
{
    public class AgrupamentoService : Base
    {
        public AgrupamentoService(IUnitOfWork unit) : base(unit)
        {
        }

        public async Task UpdateNome(int id, string nome)
        {
            var db = new AgrupamentoRepository(Unit);
            var data = await db.Find(id);
            data.Nome = nome;
            await db.Update(data);
        }
    }
}
