using PatientTracking.Core.Signatures;

namespace PatientTracking.Entities.Concrete
{
    public class PatientDisease : IBaseEntity
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public int DiseaseId { get; set; }

        public Patient Patient { get; set; }
        public Disease Disease { get; set; }

    }
}
