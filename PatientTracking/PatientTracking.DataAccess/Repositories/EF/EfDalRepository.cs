using PatientTracking.Core.Repositories.EF;
using PatientTracking.Core.Signatures;
using PatientTracking.DataAccess.Contexts.EF;

namespace PatientTracking.DataAccess.Repositories.EF
{
    public class EfDalRepository<TEntity> : EfRepository<TEntity, PatientTrackingContext>,IDalRespository<TEntity>
        where TEntity : class, IBaseEntity, new()
    {
        public EfDalRepository(PatientTrackingContext context) : base(context)
        {
        }
    }
}
