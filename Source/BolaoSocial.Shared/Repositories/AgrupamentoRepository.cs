using BolaoSocial.Shared.Contracts;
using BolaoSocial.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BolaoSocial.Shared.Repositories
{
    public class AgrupamentoRepository : Base<Agrupamento>
    {
        public AgrupamentoRepository(IUnitOfWork unit) : base(unit)
        {
        }

        public AgrupamentoRepository(IDataRead reader, IDataWrite writer) : base(reader, writer)
        {
        }
    }
}
