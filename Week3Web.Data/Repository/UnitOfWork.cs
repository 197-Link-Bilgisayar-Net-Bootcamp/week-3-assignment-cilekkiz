using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week3Web.Data.Database;

namespace Week3Web.Data.Repository
{
    public class UnitOfWork
    {
        private readonly WebContext _webContext;
        private IDbContextTransaction _transaction;
        public UnitOfWork(WebContext webContext)
        {
            _webContext = webContext;
            _transaction = null;
        }
        public IDbContextTransaction BeginTransaction()
        {
            _transaction = _webContext.Database.BeginTransaction();
            return _transaction;
        }
        public async Task CommitAsync()
        {
            await _webContext.SaveChangesAsync();
        }
        public async Task RollBackAsync()
        {
            await _webContext.Database.RollbackTransactionAsync();
        }
    }
}
