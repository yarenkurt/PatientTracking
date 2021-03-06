using PatientTracking.Core.Signatures;

namespace PatientTracking.Entities.Concrete
{
    public class Hospital:IBaseEntity
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public int DistrictId { get; set; }

        public District District { get; set; }
    }
}
