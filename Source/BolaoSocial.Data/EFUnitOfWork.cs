using BolaoSocial.Shared.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;

namespace BolaoSocial.Data
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private readonly EFDataContext dbcontext;
        private IDbContextTransaction currentTr;

        public EFUnitOfWork(DbContextOptions<EFDataContext> options, IDataRead reader)
        {
            this.ReadContext = reader;
            if (reader is EFDataContext) {
                dbcontext = (EFDataContext)reader;
            }
            else {
                dbcontext = new EFDataContext(options);
            }
        }

        public IDataRead ReadContext { get; }

        public IDataWrite WriteContext => dbcontext;

        public bool HasTransaction { get; private set; }

        public IDataTransaction BeginTransaction()
        {

            currentTr = !HasTransaction ? dbcontext.Database.BeginTransaction() : currentTr;
            var entitytr = new EFTransaction(currentTr, HasTransaction);
            HasTransaction = true;
            entitytr.OnCommit += OnFinishTransaction;
            entitytr.OnRollback += OnFinishTransaction;
            return entitytr;
        }

        void OnFinishTransaction(object sender, EventArgs e)
        {
            HasTransaction = false;
        }
    }
}
