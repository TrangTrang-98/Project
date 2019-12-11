using ApplicationCore.Interfaces;
using System.Collections.Generic;
using ApplicationCore.Entities.DoctorAggregate;
using ApplicationCore.DTO;
using AutoMapper;
using ApplicationCore.Specifications;
using System.Linq;
using Presentation.ViewModel;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;

namespace Presentation.Services
{
    public class DoctorService: IDoctorService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
          private int pageSize = 5;
        public DoctorService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public IEnumerable<string> GetNames()
        {
           return  _unitOfWork.Doctors.GetNames();
            
        }
         public Doctor GetDoctor(string id)
         {
             return _unitOfWork.Doctors.GetBy(id);
         }

         public Doctor getRandDoctorID(string dept)
         {
            Doctor[] dtor = _unitOfWork.Doctors.getIdsByDept(dept);
            if(dtor.Count()== 0)
                return null;
            Random r = new Random();
            return dtor[r.Next(0,dtor.Length)];
         }
         public IEnumerable<DoctorsDTO> GetDoctors(int pageIndexs, int pageSize, out int count)// out chi lay ra
         {
             count = 4; 
             var doctorSpecPaging = new DoctorSpecification(pageIndexs, pageSize);

            var doctors = _unitOfWork.Doctors.Find(doctorSpecPaging);
            return _mapper.Map<IEnumerable<Doctor>, IEnumerable<DoctorsDTO>>(doctors);
         }

         
        public DoctorPageVM GetDoctorPageViewModel(string searchString, int pageIndex = 1)
        {
            
            var names = _unitOfWork.Doctors.GetNames();
        
            var rs = _unitOfWork.Doctors.GetAll();

             var doctors = _mapper.Map<IEnumerable<Doctor>, IEnumerable<DoctorsDTO>>(rs);

            return new DoctorPageVM
            {
                Names = new SelectList(names),
                ListDoctor = PaginatedList<DoctorsDTO>.Create(doctors, pageIndex, pageSize)
            };
        }
         
        public IEnumerable<string> GetAllDept()
        {
            return _unitOfWork.Departments.GetDeptIds();
           
        }

        public IEnumerable<string> AllDoctorId()
         {
             return _unitOfWork.Doctors.AllDoctorId();
         }

        // public IQueryable<Doctor> GetAllDoctors()
        // {
        //     return _unitOfWork.Doctors.GetAllDoctors();
           
        // }

         public void CreateDoctor(Doctor doctor)
         {
             _unitOfWork.Doctors.Add(doctor);
            _unitOfWork.Complete(); 
         }
         public void UpdateDoctor(Doctor doctor)
         {
             _unitOfWork.Doctors.Update(doctor);
            _unitOfWork.Complete();   
         }
         public void DeleteDoctor(string id)
         {
              var doctor = _unitOfWork.Doctors.GetBy(id);

            if (doctor == null) return;

            _unitOfWork.Doctors.Remove(doctor);

            _unitOfWork.Complete();
         }

    }
}