using BolaoSocial.Shared.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BolaoSocial.Shared.Contracts
{
    public interface IDataRead
    {
        Task<TModel> Find<TModel>(int id)
            where TModel : class, IModel;

        Task<TModel> Find<TModel>(string codigo)
            where TModel : class, IModel;

        Task<IQueryable<TModel>> GetQuery<TModel>()
            where TModel : class, IModel;
    }
}
