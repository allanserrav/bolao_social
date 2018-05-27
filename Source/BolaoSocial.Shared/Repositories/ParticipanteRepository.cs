using BolaoSocial.Shared.Contracts;
using BolaoSocial.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BolaoSocial.Shared.Repositories
{
    public class ParticipanteRepository : Base<Participante>
    {
        public ParticipanteRepository(IUnitOfWork unit) : base(unit)
        {
        }

        public ParticipanteRepository(IDataRead reader, IDataWrite writer) : base(reader, writer)
        {
        }
    }
}
