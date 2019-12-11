using ApplicationCore.Entities.PatientAggregate;
using ApplicationCore.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;
using Presentation.ViewModel;
namespace Presentation.Services
{
    public interface IPatientService
    {
        Patient GetPatient(string id);

        Patient GetPatientByAccountID(string user);

        IEnumerable<PatientsDTO> GetPatients(int pageIndex, int pageSize, out int count);
        IEnumerable<string> GetNamePatients(); // ds ten benh nhan(de loc)
        PatientPageVM GetPatientPageViewModel(int pageIndex);
        Patient GetMedicalRecord(string IDPatient);
        
        void CreatePatient(Patient Patient); // dang ki benh nhan
        void UpdatePatient(Patient Patient);
    
        void DeletePatient(string id);
    }
}