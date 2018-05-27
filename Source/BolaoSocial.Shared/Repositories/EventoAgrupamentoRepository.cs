using BolaoSocial.Shared.Contracts;
using BolaoSocial.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BolaoSocial.Shared.Repositories
{
    public class EventoAgrupamentoRepository : Base<EventoAgrupamento>
    {
        public EventoAgrupamentoRepository(IUnitOfWork unit) : base(unit)
        {
        }

        public EventoAgrupamentoRepository(IDataRead reader, IDataWrite writer) : base(reader, writer)
        {
        }
    }
}
