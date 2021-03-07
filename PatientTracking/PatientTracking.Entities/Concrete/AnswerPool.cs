using PatientTracking.Core.Signatures;

namespace PatientTracking.Entities.Concrete
{
    public class AnswerPool:IBaseEntity
    {
        public int Id { get; set; }
        public int QuestionPoolId { get; set; }
        public string Description { get; set; }
        public decimal Point { get; set; }

        public QuestionPool QuestionPool { get; set; }

    }
}
