using BolaoSocial.Shared.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BolaoSocial.Data
{
    public static class IncludeAll
    {
        public static IQueryable<TModel> Resolve<TModel>(DbSet<TModel> set)
            where TModel : class, IModel
        {
            return set;
        }
    }
}
