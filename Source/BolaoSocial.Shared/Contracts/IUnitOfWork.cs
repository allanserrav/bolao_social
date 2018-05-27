using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BolaoSocial.Shared.Contracts
{
    public interface IUnitOfWork
    {
        IDataRead ReadContext { get; }

        IDataWrite WriteContext { get; }

        IDataTransaction BeginTransaction();

        bool HasTransaction { get; }
    }
}
