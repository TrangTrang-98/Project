using ApplicationCore.Entities.DoctorAggregate;
using System.Collections.Generic;
using ApplicationCore.DTO;
using System.Linq;
using ApplicationCore.Entities;
using Presentation.ViewModel;
using ApplicationCore.Entities.PatientAggregate;
namespace Presentation.Services
{
    public interface IEnrollmentService
    {
        IEnumerable<string> AllPatientId();
        Patient GetPatient(string id);
        // Enrollment GetEnrollment(string IDPatient, string IDDoctor);
        Enrollment GetEnrollmentIDPatient(string IDPatient);
        Enrollment GetEnrollment(string IDPatient);
         IEnumerable<string> AllDoctorId();
        EnrollmentPageVM GetEnrollmentPageViewModel(int pageIndex);
        void CreateEnrollment(Enrollment enrollment);
        void UpdateEnrollment(Enrollment enrollment);

        void DeleteEnrollment(string id);
    }
}