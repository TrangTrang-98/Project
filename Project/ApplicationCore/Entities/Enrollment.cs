using ApplicationCore.Entities.PatientAggregate;
using ApplicationCore.Entities.DoctorAggregate;
using ApplicationCore.Interfaces;
namespace ApplicationCore.Entities
{
    public class Enrollment : IAggregateRoot
    {
        public string PatientId{get; set;}
        public string DoctorId{get; set;}
        public Patient Patient{get; set;}

        public Doctor Doctor{get; set;}
        public System.DateTime EnrollmentDate{get; set;}
        
    }
}