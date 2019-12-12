using ApplicationCore.Entities.PatientAggregate;
using ApplicationCore.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace Presentation.Services
{
    public interface IMedicalRecordService
    {
        MedicalRecord GetMedicalRecord(string medicalrecordid);
        IEnumerable<MedicalRecordDTO> GetMedicalRecords(int pageIndex, int pageSize, out int count);
        //IEnumerable<string> GetNamePatients(); // ds ten benh nhan(de loc)
        
        void CreateMedicalRecord(MedicalRecord MedicalRecord); // dang ki benh nhan
        void UpdateMedicalRecord(MedicalRecord Medicalrecord);
    
        void DeleteMedicalRecord(string medicalrecordid);
    }
}