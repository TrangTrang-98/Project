using ApplicationCore.Entities.PatientAggregate;
using System.Collections.Generic;
namespace ApplicationCore.Interfaces
{
    public interface IMedicalRecordRepository : IRepository<MedicalRecord>
    {
         IEnumerable<string> GetMedicalRecordNames();
          IEnumerable<string> AllMedicalRecordId();

         
        
    }
}