using PowerCalendar.Infrastructure.Data.RepositoryContract;
using System;

namespace PowerCalendar.Infrastructure.Data.RepositoryServiceSqlServer
{
    public class TransactionScopeSqlServer : ITransactionScope
    {
        private readonly IRepository _repository = null;
        private bool _hasState = false;
        private bool _isRecreateStateWhenDisposing = false;
        private bool disposedValue = false;
        public TransactionScopeSqlServer(IRepository repository, bool hasState, bool isRecreateStateWhenDisposing)
        {
            _repository = repository;
            _hasState = hasState;
            _isRecreateStateWhenDisposing = isRecreateStateWhenDisposing;
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if ((disposing) && (_hasState))
                    this._repository.Commit(null);
                disposedValue = true;
                _hasState = false;
                if (_isRecreateStateWhenDisposing)
                    this._repository.EnsureTransaction();
            }
        }

        void IDisposable.Dispose()
        {
            Dispose(true);
        }

        public void Complete()
        {
            if (!this._hasState)
                return;
            this._repository.Commit(null);
            this._hasState = false;
        }

        public void Rollback()
        {
            this._repository.Rollback(null);
            this._hasState = false;
        }
    }
}
