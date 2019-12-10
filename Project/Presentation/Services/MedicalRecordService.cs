using ApplicationCore.Interfaces;
using ApplicationCore.Entities.PatientAggregate;
using System.Collections.Generic;
using ApplicationCore.DTO;
using ApplicationCore.Specifications;
using ApplicationCore;
using ApplicationCore.Entities;
using AutoMapper;
using System.Threading.Tasks;
// service : using to implement get, add, delete, update
namespace Presentation.Services
{
    public class MedicalRecordService : IMedicalRecordService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public MedicalRecordService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
      /*  public  IEnumerable<string> GetNamePatients()
        {  
               return _unitOfWork.Patients.GetNames();
        }*/

        //  public  string GetAddressPatient(string id)
        // {  
        //        return _unitOfWork.Patients.GetAddress(id);
        // }

         public MedicalRecord GetMedicalRecord(string medicalrecordid)
         {
             return _unitOfWork.MedicalRecords.GetBy(medicalrecordid);
         }

         public  IEnumerable<MedicalRecordDTO> GetMedicalRecords(int pageIndexs, int pageSize, out int count)// out chi lay ra
         {
              count = 4;
             // return _unitOfWork.Patients.GetAll();


             var medicalrecordSpecPaging = new MedicalRecordSpecification(pageIndexs, pageSize);
            
            var medicalrecords =  _unitOfWork.MedicalRecords.Find(medicalrecordSpecPaging);
        
                return _mapper.Map<IEnumerable<MedicalRecord>, IEnumerable<MedicalRecordDTO>>(medicalrecords);
            }
         

         public void CreateMedicalRecord(MedicalRecord medicalrecord)
         {
             string medicalrecordid = medicalrecord.MedicalRecordId;
             _unitOfWork.MedicalRecords.Add(medicalrecord); 
             _unitOfWork.Complete(); 
            
         }
         public void UpdateMedicalRecord(MedicalRecord medicalrecord)
         {
             _unitOfWork.MedicalRecords.Update(medicalrecord);
            
            _unitOfWork.Complete();      
         }
        
       
         public void DeleteMedicalRecord(string medicalrecordid)
         {
             var medicalrecord= _unitOfWork.MedicalRecords.GetBy(medicalrecordid);

            if (medicalrecord== null) return;

            _unitOfWork.MedicalRecords.Remove(medicalrecord);

            _unitOfWork.Complete();
         }

    }
}
