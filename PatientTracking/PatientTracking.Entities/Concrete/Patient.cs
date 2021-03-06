using PatientTracking.Core.Signatures;

namespace PatientTracking.Entities.Concrete
{


    public class Patient : IBaseEntity
    {
        public int Id { get; set; }
        public int DiseaseId { get; set; }
        public int PersonId { get; set; }
        public string IdentityNumber { get; set; }
        public string Email { get; set; }

        public Person Person { get; set; }

    }
}
