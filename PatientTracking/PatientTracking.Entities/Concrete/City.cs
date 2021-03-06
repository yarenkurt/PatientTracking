using PatientTracking.Core.Signatures;

namespace PatientTracking.Entities.Concrete
{
    public class City : IBaseEntity
    {
        public int Id { get; set; }
        public int CountryId { get; set; }
        public string Description { get; set; }

        public Country Country { get; set; }
    }
}
