using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BolaoSocial.Shared.Contracts;
using BolaoSocial.Shared.Models;
using BolaoSocial.Shared.Repositories;

namespace BolaoSocial.Shared.Services
{
    public class CompeticaoService : Base
    {
        public CompeticaoService(IUnitOfWork unit) : base(unit)
        {
        }

        public async Task UpdateNome(int id, string nome)
        {
            var db = new CompeticaoRepository(Unit);
            var data = await db.Find(id);
            data.Nome = nome;
            await db.Update(data);
        }

        public async Task UpdateTipo(int id, EventoType tipo)
        {
            var db = new CompeticaoRepository(Unit);
            var data = await db.Find(id);
            if(data.Eventos != null)
            {
                //TODO: Verificar se cada evento segue a regra do evento novo.

            }
            data.EventoTipo = tipo;
            await db.Update(data);
        }
    }
}
