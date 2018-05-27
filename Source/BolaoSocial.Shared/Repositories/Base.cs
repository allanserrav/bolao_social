using BolaoSocial.Shared.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BolaoSocial.Shared.Repositories
{
    public abstract class Base<TModel>
        where TModel : Models.Base, IModel
    {
        public Base(IUnitOfWork unit)
        {
            Reader = unit.ReadContext;
            Writer = unit.WriteContext;
        }

        public Base(IDataRead reader, IDataWrite writer)
        {
            Reader = reader;
            Writer = writer;
        }

        protected IDataRead Reader { get; }
        protected IDataWrite Writer { get; }

        public Task<TModel> Find(int id)
        {
            return Reader.Find<TModel>(id);
        }

        public Task<TModel> Find(string codigo)
        {
            return Reader.Find<TModel>(codigo);
        }

        public async Task Add(TModel data)
        {
            data.CreatedOn = data.CreatedOn.Equals(DateTime.MinValue) ? DateTime.Now : data.CreatedOn;
            await Writer.Add(data);
        }

        public Task<int> Update(TModel data)
        {
            data.UpdatedOn = DateTime.Now;
            return Writer.Update(data);
        }

        public async Task Desabilitar(int id)
        {
            var data = await Find(id);
            data.ObjDesabilitado = true;
            await Update(data);
        }

        public async Task Delete(int id)
        {
            var data = await Find(id);
            await Delete(data);
        }

        public Task Delete(TModel data)
        {
            return Writer.Delete(data);
        }
    }
}
