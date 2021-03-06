using PatientTracking.Core.Signatures;

namespace PatientTracking.Entities.Concrete
{
    public class District : IBaseEntity
    {
        public int Id { get; set; }
        public int CityId { get; set; }
        public string Description { get; set; }

        public City City { get; set; }
    }
}
