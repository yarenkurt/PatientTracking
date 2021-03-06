using PatientTracking.Core.Results;
using PatientTracking.Core.Signatures;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PatientTracking.Business.Repositories
{
    public interface IServiceRepository<TDto>
        where TDto : class, IBaseDto
    {

        Task<bool> AnyAsync(int id);

        Task<TDto> GetAsync(int id);

        Task<DataResult<TDto>> InsertAsync(TDto dto);

        Task<Result> UpdateAsync(TDto dto);

        Task<Result> DeleteAsync(int id);

    }
}
