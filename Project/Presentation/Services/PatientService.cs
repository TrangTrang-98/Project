using ApplicationCore.Interfaces;
using ApplicationCore.Entities.PatientAggregate;
using System.Collections.Generic;
using ApplicationCore.DTO;
using ApplicationCore.Specifications;
using ApplicationCore;
using ApplicationCore.Entities;
using AutoMapper;
using System.Threading.Tasks;
using Presentation.ViewModel;
// service : using to implement get, add, delete, update
namespace Presentation.Services
{
    public class PatientService : IPatientService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        private int pageSize = 7;

        public PatientService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public  IEnumerable<string> GetNamePatients()
        {  
               return _unitOfWork.Patients.GetNames();
        }

        //  public  string GetAddressPatient(string id)
        // {  
        //        return _unitOfWork.Patients.GetAddress(id);
        // }

         public Patient GetPatient(string id)
         {
             return _unitOfWork.Patients.GetBy(id);
         }

        public Patient GetPatientByAccountID(string user)
        {
            return _unitOfWork.Patients.GetPatientIDByAccountID(user);
        }

         public  IEnumerable<PatientsDTO> GetPatients(int pageIndexs, int pageSize, out int count)// out chi lay ra
         {
              count = 4;
             // return _unitOfWork.Patients.GetAll();


             var patientSpecPaging = new PatientSpecification(pageIndexs, pageSize);
            
            var patients =  _unitOfWork.Patients.Find(patientSpecPaging);
        
                return _mapper.Map<IEnumerable<Patient>, IEnumerable<PatientsDTO>>(patients);
            }
          public PatientPageVM GetPatientPageViewModel(int pageIndex = 1)
        {
       
            var rs = _unitOfWork.Patients.GetAll();
            var patients = _mapper.Map<IEnumerable<Patient>, IEnumerable<PatientsDTO>>(rs);
            return new PatientPageVM
            {
                ListPatient = PaginatedList<PatientsDTO>.Create(patients, pageIndex, pageSize)
            };
        }

         public Patient GetPatientByAccountID(string user)
        {
            return _unitOfWork.Patients.GetPatientIDByAccountID(user);
        }
         
         public Patient GetMedicalRecord(string IDPatient)
        {
            
            return _unitOfWork.Patients.GetMeRecordID(IDPatient);
        }
         public void CreatePatient(Patient patient)
         {
             string id = patient.Id;
             _unitOfWork.Patients.Add(patient); 
             _unitOfWork.Complete(); 
            
         }
         public void UpdatePatient(Patient patient)
         {
             _unitOfWork.Patients.Update(patient);
            
            _unitOfWork.Complete();      
         }
        
       
         public void DeletePatient(string id)
         {
             var patient = _unitOfWork.Patients.GetBy(id);

            if (patient == null) return;

            _unitOfWork.Patients.Remove(patient);

            _unitOfWork.Complete();
         }

    }
}
