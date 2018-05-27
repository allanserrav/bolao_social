using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BolaoSocial.Shared.Contracts
{
    public interface IDataTransaction : IDisposable
    {
        void Commit();

        void Rollback();
    }
}
