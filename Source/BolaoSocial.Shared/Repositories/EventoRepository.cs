using BolaoSocial.Shared.Contracts;
using BolaoSocial.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BolaoSocial.Shared.Repositories
{
    public class EventoRepository : Base<Evento>
    {
        public EventoRepository(IUnitOfWork unit) : base(unit)
        {
        }

        public EventoRepository(IDataRead reader, IDataWrite writer) : base(reader, writer)
        {
        }

        protected override Task PreAdd(Evento data)
        {
            base.PreAdd(data);
            foreach (var item in data.Participantes)
            {
                item.CreatedOn = data.CreatedOn;
                item.Evento = data;
                //Writer.Attach(item.Participante);
            }
            foreach (var item in data.Agrupamentos)
            {
                item.CreatedOn = data.CreatedOn;
                item.Evento = data;
                //Writer.Attach(item.Agrupamento);
            }
            return Task.CompletedTask;
        }
    }
}
