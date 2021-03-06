using PatientTracking.Business.Repositories;
using PatientTracking.Core.Models;
using PatientTracking.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PatientTracking.Business.Abstract
{
    public interface ICountryService : IServiceRepository<CountryDto>
    {
        Task<List<CountryDto>> GetAllAsync();
        Task<List<SelectList>> SelectList();
    }
}
