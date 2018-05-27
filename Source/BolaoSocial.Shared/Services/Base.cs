using BolaoSocial.Shared.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace BolaoSocial.Shared.Services
{
    public abstract class Base
    {
        public Base(IUnitOfWork unit)
        {
            Unit = unit;
        }

        public IUnitOfWork Unit { get; }
    }
}
