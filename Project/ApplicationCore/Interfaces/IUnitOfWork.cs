
namespace ApplicationCore.Interfaces
{
    // including interface _Repository..
    public interface IUnitOfWork
    {
        IPatientRepository Patients{get;}
        IDoctorRepository Doctors{get;}
        IDepartmentRepository Departments{get;}
        IEnrollmentRepository Enrollments{get;}
        IAccountRepository Accounts{get;}
          IMedicalRecordRepository MedicalRecords{get;}
        // bo sung them nhung repository khac

        int Complete();
    }
}