using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PatientTracking.Core.Results;
using PatientTracking.Core.Signatures;
using PatientTracking.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PatientTracking.Business.Repositories
{
    public class ServiceRepository<TEntity, TDto> : IServiceRepository<TDto>
        where TEntity : class, IBaseEntity, new()
        where TDto : class, IBaseDto
    {
        private readonly IDalRespository<TEntity> _dal;
        private readonly IMapper _mapper;
        public ServiceRepository(IDalRespository<TEntity> dal, IMapper mapper)
        {
            _dal = dal;
            _mapper = mapper;
        }

        public async Task<bool> AnyAsync(int id) => await _dal.GetAsync(id) != null;

        public async Task<Result> DeleteAsync(int id)
        {
            var entity = await _dal.GetAsync(id);
            return await _dal.DeleteAsync(entity);
        }

        public async Task<TDto> GetAsync(int id)
        {
            var entity = await _dal.GetAsync(id);
            return _mapper.Map<TDto>(entity);
        }

        public async Task<DataResult<TDto>> InsertAsync(TDto dto)
        {
            var entity = _mapper.Map<TEntity>(dto);
            var result = await _dal.InsertAsync(entity);
            if (!result.Success) return new ErrorDataResult<TDto>(result.Message);
            return new SuccessDataResult<TDto>(_mapper.Map<TDto>(result.Data));
        }

        public async Task<Result> UpdateAsync(TDto dto)
        {
            var entity = _mapper.Map<TEntity>(dto);
            return await _dal.UpdateAsync(entity);
        }
    }
}
