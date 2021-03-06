using PatientTracking.Core.Repositories;
using PatientTracking.Core.Signatures;
using System;
using System.Collections.Generic;
using System.Text;

namespace PatientTracking.DataAccess.Repositories
{
   public interface IDalRespository<TEntity>:IRepository<TEntity>
        where TEntity : class, IBaseEntity, new()
    {

    }
}
