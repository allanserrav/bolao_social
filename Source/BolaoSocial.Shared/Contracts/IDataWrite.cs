using BolaoSocial.Shared.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BolaoSocial.Shared.Contracts
{
    public interface IDataWrite
    {
        Task Add<TModel>(TModel model)
            where TModel : class, IModel;

        Task Delete<TModel>(TModel model)
            where TModel : class, IModel;

        Task<int> Update<TModel>(TModel model)
            where TModel : class, IModel;
    }
}
