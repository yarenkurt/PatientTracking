using PatientTracking.Core.Signatures;

namespace PatientTracking.Entities.Concrete
{
    public class Doctor : IBaseEntity
    {
        public int Id { get; set; }
        public int DeparmentId { get; set; }
        public int DegreeId { get; set; }
        public int PersonId { get; set; }
        public string Email { get; set; }
        public bool IsBlocked { get; set; }

        public Department Deparment { get; set; }
        public Degree Degree { get; set; }
        public Person Person { get; set; }

    }
}
