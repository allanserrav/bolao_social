using BolaoSocial.Shared.Contracts;
using BolaoSocial.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BolaoSocial.Shared.Repositories
{
    public class CompeticaoRepository : Base<Competicao>
    {
        public CompeticaoRepository(IUnitOfWork unit) : base(unit)
        {
        }

        public CompeticaoRepository(IDataRead reader, IDataWrite writer) : base(reader, writer)
        {
        }
    }
}
