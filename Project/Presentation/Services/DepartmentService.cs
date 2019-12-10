using ApplicationCore.Entities;
using System.Collections.Generic;
using ApplicationCore.Interfaces;
using AutoMapper;
using ApplicationCore.DTO;
using ApplicationCore.Specifications;
using ApplicationCore.Entities.DoctorAggregate;
using Presentation.ViewModel;
namespace Presentation.Services
{
    public class DepartmentService : IDepartmentService
    {
         private int pageSize = 5;
         private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DepartmentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        
        public  IEnumerable<string> GetNameDepartments()
        {  
               return _unitOfWork.Departments.GetNames();
        }

        //  public  string GetAddressPatient(string id)
        // {  
        //        return _unitOfWork.Patients.GetAddress(id);
        // }

         public Department GetDepartment(string id)
         {
             return _unitOfWork.Departments.GetBy(id);
         }

        public IEnumerable<string> GetDoctorNames()
        {
            return _unitOfWork.Doctors.GetNames();
        }
        
         public  IEnumerable<DepartmentsDTO> GetDepartments(int pageIndexs, int pageSize, out int count)// out chi lay ra
         {
              count = 4;
             // return _unitOfWork.Patients.GetAll();


             var deptSpecPaging = new DeptSpecification(pageIndexs, pageSize);
            
            var depts =  _unitOfWork.Departments.Find(deptSpecPaging);
        
                return _mapper.Map<IEnumerable<Department>, IEnumerable<DepartmentsDTO>>(depts);
            }

        public DepartmentPageVM GetDepartmentPageViewModel(int pageIndex = 1)
        {
       
            var rs = _unitOfWork.Departments.GetAll();
            var departments = _mapper.Map<IEnumerable<Department>, IEnumerable<DepartmentsDTO>>(rs);
            return new DepartmentPageVM
            {
                ListDept = PaginatedList<DepartmentsDTO>.Create(departments, pageIndex, pageSize)
            };
        }
         
         public void CreateDepartment(Department dept)
         {
             
             _unitOfWork.Departments.Add(dept); 
             _unitOfWork.Complete(); 
            
         }
         public void UpdateDepartment(Department dept)
         {
            _unitOfWork.Departments.Update(dept);
            _unitOfWork.Complete();   

            // string id = patient.PatientId;
            // if(id == null) return null;
            // else{
                
            // }
         }
         public void DeleteDepartment(string id)
         {
             var dept = _unitOfWork.Departments.GetBy(id);

            if (dept == null) return;

            _unitOfWork.Departments.Remove(dept);

            _unitOfWork.Complete();
         }

    }
}