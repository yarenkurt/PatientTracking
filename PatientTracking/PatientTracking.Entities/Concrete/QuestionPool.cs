using PatientTracking.Core.Enums;
using PatientTracking.Core.Signatures;
using System;
using System.Collections.Generic;
using System.Text;

namespace PatientTracking.Entities.Concrete
{
    public class PatientQuestion:IBaseEntity
    {
        public int Id { get; set; }
        public int QuestionPoolId { get; set; }
        public int PatientId { get; set; }
        public int Day { get; set; }
        public DateTime CreatedAt { get; set; }



        public QuestionPool QuestionPool { get; set; }
        public Patient Patient { get; set; }
    }
    public class QuestionPool:IBaseEntity
    {
        public int Id { get; set; }
        public int DepartmentId { get; set; }
        public string Description { get; set; }
        public int UpperLimit { get; set; }
        public int LowerLimit { get; set; }
        public QuestionType QuestionType { get; set; }


        public Department Department { get; set; }

    }
}
