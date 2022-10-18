using System;
using System.Collections.Generic;
using System.Text;

namespace PowerCalendar.Infrastructure.Data.RepositoryContract
{
    public interface ITransactionScope : IDisposable
    {
        void Complete();
        void Rollback();
    }
}
