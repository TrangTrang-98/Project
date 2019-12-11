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
    
         IEnumerable<string> AllDoctorId();
        EnrollmentPageVM GetEnrollmentsByPatientID(string id,int pageIndex = 1);
         string generateID();
        EnrollmentPageVM GetEnrollmentPageViewModel(int pageIndex);
        void CreateEnrollment(Enrollment enrollment);
        void UpdateEnrollment(Enrollment enrollment);
    }
}