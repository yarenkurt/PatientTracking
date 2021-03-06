using PatientTracking.Core.Signatures;


namespace PatientTracking.Entities.Concrete
{
    public class Disease : IBaseEntity
    {
        public int Id { get; set; }
        public int DeparmentId { get; set; }
        public string Description { get; set; }

        public Deparment Deparment { get; set; }

    }
}
