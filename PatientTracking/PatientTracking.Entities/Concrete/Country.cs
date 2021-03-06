using PatientTracking.Core.Signatures;

namespace PatientTracking.Entities.Concrete
{
    public class Country : IBaseEntity
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string CountryCode { get; set; }
    }
}
