using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PatientTracking.Business.Abstract;
using PatientTracking.Business.Repositories;
using PatientTracking.Core.Models;
using PatientTracking.Core.Results;
using PatientTracking.DataAccess.Repositories;
using PatientTracking.Entities.Concrete;
using PatientTracking.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientTracking.Business.Concrete
{
    public class CountryService : ServiceRepository<Country, CountryDto>, ICountryService
    {
        private readonly IDalRespository<Country> _dal;
        private readonly IMapper _mapper;
        public CountryService(IDalRespository<Country> dal, IMapper mapper) : base(dal, mapper)
        {
            _dal = dal;
            _mapper = mapper;

        }

        public async Task<List<CountryDto>> GetAllAsync()
        {
            var entities = await _dal.TableNoTracking.OrderBy(x => x.Description).ToListAsync();

            return _mapper.Map<List<CountryDto>>(entities);
        }

        public async Task<List<SelectList>> SelectList()
        {
            return await _dal.TableNoTracking.OrderBy(x => x.Description).Select(x => new SelectList
            {
                Id = x.Id,
                Description = x.Description
            }).ToListAsync();
        }
    }
}
