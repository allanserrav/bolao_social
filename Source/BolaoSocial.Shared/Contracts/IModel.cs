using System;

namespace BolaoSocial.Shared.Contracts
{
    public interface IModel
    {
        int Id { get; }

        string Codigo { get; }

        DateTime CreatedOn { get; }

        DateTime? UpdatedOn { get; }

        bool ObjDesabilitado { get; set; }
    }
}
